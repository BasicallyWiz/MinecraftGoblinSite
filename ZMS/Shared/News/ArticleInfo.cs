using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZMS.Shared.News
{
  public class ArticleInfo
  {
    public string Title { get; set; }
    public string? Thumbnail { get; set; }
    public string Description { get; set; }
    public ulong[] Authors { get; set; }
    public DateTime Published { get; set; }
    public string? Content { get; set; }
  
    [JsonConstructor]
    public ArticleInfo(string Title, string? Thumbnail, string Description, ulong[] Authors, DateTime Published)
    {
      this.Title = Title;
      this.Thumbnail = Thumbnail;
      this.Description = Description;
      this.Authors = Authors;
      this.Published = Published;
    }

    public ArticleInfo() {
      Title = "Unnamed Article";
      Thumbnail = null;
      Description = "No description provided.";
      Authors = new ulong[] { 0 };
      Published = DateTime.Now;
    }
  }
}
