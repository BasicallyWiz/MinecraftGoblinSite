using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace ZMS.Client.Pages
{
  partial class NewsManage
  {
    [Inject] public IJSRuntime JS { get; set; }
    [Inject] public NavigationManager NavMan { get; set; }
    [Inject] public HttpClient Http { get; set; }
    bool? IsLoggedIn { get; set; }
    protected override async Task OnInitializedAsync()
    {
      if (await LoginWithToken() || await LoginWithDiscord()) IsLoggedIn = true;
      else IsLoggedIn = false;

      await base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      return base.OnAfterRenderAsync(firstRender);
    }
    
    /// <summary>
    /// Checks client cookie for login token, and compares with server.
    /// </summary>
    /// <returns>A <see cref="bool"/> determining if successful.</returns>
    async Task<bool> LoginWithToken() {
      Console.WriteLine("LoginWithToken started");
      if (NavMan.Uri.Contains("code=")) {
        Console.WriteLine("LoginWithToken aborted. Url contained \"code\" param.");
        return false;
      }
      string Cookies = await JS.InvokeAsync<string>("document.cookies.get", "");
      Console.WriteLine($"Cookies retrieved: {Cookies}");
      if (Cookies.Contains("SessionToken"))
      {
        foreach (string cookie in Cookies.Split("; "))
        {
          if (cookie.Split("=")[0] != "SessionToken") continue;
          var result = await Http.GetAsync($"{NavMan.BaseUri}api/Profile/AccessToken?AccessToken={cookie.Split("=")[1]}");
          if (await result.Content.ReadAsStringAsync() == "true")
          {
            Console.WriteLine("LoginWithToken finished");
            return true;
          }
          Console.WriteLine("LoginWithToken failed. Server returned false.");
          return false;
        }
        Console.WriteLine("LoginWithToken failed. This route should have been impossible. (AccessToken exists, but also doesn't???)");
        return false;
      }
      else 
      {
        Console.WriteLine("LoginWithToken failed. No AccessToken cookie");
        return false;
      }
    }
    async Task<bool> LoginWithDiscord() {
      Console.WriteLine("LoginWithDiscord started");
      if (NavMan.Uri.Split("?").Count() > 1) {
        string parameters = NavMan.Uri.Split("?")[1];
        foreach (string parameter in parameters.Split("&"))
        {
          if (parameter.Split("=")[0] != "code") continue;
          var result = await Http.PutAsync($"{NavMan.BaseUri}api/Profile?AuthCode={parameter.Split("=")[1]}", null);
          JS.InvokeVoidAsync("document.cookies.set", $"SessionToken={await result.Content.ReadAsStringAsync()}");
          return true;
        }
        Console.WriteLine("LoginWithDiscord failed. No code parameter");
        return false;
      }
      else {
        Console.WriteLine("LoginWithDiscord failed. No url parameters.");
        return false;
      }
    }
  }
}
