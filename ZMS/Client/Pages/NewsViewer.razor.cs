using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ZMS.Client.Shared.News;
using ZMS.Shared.News;
namespace ZMS.Client.Pages
{
  partial class NewsViewer
  {
    [Inject] public NavigationManager NavMan { get; set; }
    [Inject] public HttpClient Http { get; set; }
    [Inject] public IJSRuntime JS { get; set; }
    [Parameter]
    [SupplyParameterFromQuery]
    public string issue { get; set; }
    public Issue? Issue { get; set; }
    public List<ArticleInfo>? Articles { get; set; } = new();

    override protected async Task OnInitializedAsync()
    {
      Issue = await Http.GetFromJsonAsync<Issue>($"{NavMan.BaseUri}api/cdn?file=Issues/{issue}.json");
      Console.WriteLine($"Recieved issue: {Issue.Title}");
      JS.InvokeVoidAsync("console.table", Issue);

      foreach (string article in Issue.Articles)
      {
        ArticleInfo result = await Http.GetFromJsonAsync<ArticleInfo>($"{NavMan.BaseUri}api/cdn?file=Articles/{article}.md.json");
        result.Content = await Http.GetStringAsync($"{NavMan.BaseUri}api/cdn?file=Articles/{article}.md");
        await JS.InvokeVoidAsync("console.table", result);
        Articles.Add(result);
      }
    }
  }
}
