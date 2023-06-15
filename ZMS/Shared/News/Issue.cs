using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZMS.Shared.News
{
  [JsonSerializable(typeof(Issue))]
  public class Issue
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string? Thumbnail { get; set; }
    public ulong[] Authors { get; set; }
    public DateTime Published { get; set; }
    public string[] Articles { get; set; }
    public string Path { get; set; }

    [JsonConstructor]
    public Issue(string Title, string Description, string? Thumbnail, ulong[] Authors, DateTime Published, string[] Articles, string Path)
    {
      this.Title = Title;
      this.Description = Description;
      this.Thumbnail = Thumbnail;
      this.Authors = Authors;
      this.Published = Published;
      this.Articles = Articles;
      this.Path = Path;
    }
  }
}
