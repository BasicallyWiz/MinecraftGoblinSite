using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ZMS.Client.Pages
{
  partial class Index
  {
    [Inject]
    public IJSRuntime? JS { get; set; }
    public List<string> Subtitles { get; set; } = new() { 
      "It's definitely an interesting name.",
      "There will be zombies, but not yet.",
      "This site was made with C#. I wish I could make Spigot plugins with C#.",
      "I definitely do not use hentai as placeholder images.",
      "Is it a chicken or is it a duck?",
      "Were you at MINECON? I wasn't."
    };
    public string ActualSubtitle { get; set; }

    async Task ServerIpButtonClick() {
      await JS.InvokeVoidAsync("navigator.clipboard.writeText", "play.inocy.be");
    }

    string GetDescription() {
      return Subtitles[new Random().Next(Subtitles.Count)];
    }

    protected async override Task OnInitializedAsync() {
      ActualSubtitle = GetDescription();
      await base.OnInitializedAsync();
    }
  }
}
