using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IOFile = System.IO.File;

using ZMS.Shared.News;
namespace ZMS.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NewsController : ControllerBase
  {
    public static void SetupNewsController()
    {
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/News")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/News");
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/News/Issues")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/News/Issues");
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/News/Articles")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/News/Articles");
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/News/Media")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/News/Media");
      if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/News/Writers")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/News/Writers");

      //  TODO: Add some more placeholder articles, then change the code in the IssueIndex region to create an index of issues, and not whatever it's doing right now.
      Index();
    }

    [HttpGet("Issues")]
    public IActionResult GetIssues()
    {
      Index();
      if (IOFile.Exists($"{Directory.GetCurrentDirectory()}/News/Issues/IssueIndex.json"))
      {
        return new JsonResult(JsonSerializer.Deserialize<List<Issue>>(IOFile.ReadAllText($"{Directory.GetCurrentDirectory()}/News/Issues/IssueIndex.json")));
      }
      else return Problem("No IssueIndex file could be found on the server.", statusCode: StatusCodes.Status500InternalServerError, title: "NoIssueIndex");
    }

    [HttpGet("Articles")]
    public IActionResult GetArticles()
    {
      Index();
      if (IOFile.Exists($"{Directory.GetCurrentDirectory()}/News/Articles/ArticleIndex.json"))
      {
        return new JsonResult(JsonSerializer.Deserialize<List<ArticleInfo>>(IOFile.ReadAllText($"{Directory.GetCurrentDirectory()}/News/Articles/ArticleIndex.json")));
      }
      else return Problem("No ArticleIndex file could be found on the server.", statusCode: StatusCodes.Status500InternalServerError, title: "NoArticleIndex");
    }

    static void Index()
    {
      #region ArticleIndex
      List<ArticleInfo> articles = new List<ArticleInfo>();
      foreach(string file in Directory.GetFiles($"{Directory.GetCurrentDirectory()}/News/Articles"))
      {
        if (file.Contains("ArticleIndex")) continue;
        bool isReading = false;
        ArticleInfo articleInfo = new();
        foreach (string line in IOFile.ReadAllLines(file))
        {
          switch (line)
          {
            case "```articleinfo":
              isReading = true;
              break;

            case "```":
              articles.Add(articleInfo);
              Console.WriteLine(articleInfo.Title);
              isReading = false;
              break;

            default:
            {
                if (line.StartsWith("title:")) articleInfo.Title = line[7..];
                else if (line.StartsWith("thumbnail:")) articleInfo.Thumbnail = line[11..];
                else if (line.StartsWith("description:")) articleInfo.Description = line[13..];
                else if (line.StartsWith("authors:"))
                {
                  List<ulong> authors = new List<ulong>();
                  foreach (string author in line[9..].Replace("[", "").Replace("]", "").Split(','))
                  {
                    ulong.TryParse(author, out ulong authorId);
                    authors.Add(authorId);
                  }
                  articleInfo.Authors = authors.ToArray();
                }
                else if (line.StartsWith("date:")) articleInfo.Published = DateTime.Parse(line[5..]);
            } break;
          }

        }
      }
      IOFile.WriteAllText($"{Directory.GetCurrentDirectory()}/News/Articles/ArticleIndex.json", JsonSerializer.Serialize(articles));
      #endregion
      #region IssueIndex
      List<Issue> issues = new List<Issue>();
      foreach (string file in Directory.GetFiles($"{Directory.GetCurrentDirectory()}/News/Issues"))
      {
        if (file.Contains("IssueIndex")) continue;

        Issue tempIssue = JsonSerializer.Deserialize<Issue>(IOFile.ReadAllText(file));
        tempIssue.Path = new FileInfo(file).Name;
        issues.Add(tempIssue);
      }
      IOFile.WriteAllText($"{Directory.GetCurrentDirectory()}/News/Issues/IssueIndex.json", JsonSerializer.Serialize(issues));
      #endregion
    }
  }
}
