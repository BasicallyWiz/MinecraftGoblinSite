using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ZMS.Shared.News;

namespace ZMS.Client.Pages
{
  partial class News
  {
    [Inject]
    NavigationManager NavMan { get; set; }
    HttpClient http = new HttpClient();
    List<Issue>? issues = new List<Issue>();

    protected override async Task OnInitializedAsync()
    {
      Console.WriteLine("Getting issues...");
      var response = await http.GetAsync($"{NavMan.BaseUri}api/News/Issues");
      issues = await response.Content.ReadFromJsonAsync<List<Issue>>();
      issues.Sort((a, b) => b.Published.CompareTo(a.Published));

      await base.OnInitializedAsync();
    }
  }
}
