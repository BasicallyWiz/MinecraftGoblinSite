using Microsoft.AspNetCore.Components;

using ZMS.Shared.News;
namespace ZMS.Client.Shared.News
{
  partial class IssueListing
  {
    [Inject]
    NavigationManager NavMan { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? CapturedAttributes { get; set; }

    [Parameter]
    public Issue issue { get; set; }

    public string? getIssueThumb(string thumburl)
    {
      if (thumburl == null) return null;
      if (thumburl.StartsWith("https://") || thumburl.StartsWith("http://")) return thumburl;
      else return $"{NavMan.BaseUri}api/cdn?file=Media/{thumburl}";
    }
  }
}
