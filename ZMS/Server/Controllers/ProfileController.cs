using IOFile = System.IO.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DOA2H;

namespace ZMS.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    [HttpGet]
    public async Task<IActionResult> Get(ulong id) {
      if (IOFile.Exists($"Writers/{id}.json")) {
        return File(await IOFile.ReadAllBytesAsync($"Writers/{id}.json"), "application/json");
      }
      else {
        return NotFound($"Writer with id: \"{id}\" could not be found.");
      }
    }
    /// <summary>
    /// Takes an auth code from Discord and exchanges it for an access token using the DOA2H library.
    /// </summary>
    /// <param name="AuthCode">The Authorization code given to the user from Discord.</param>
    /// <returns>An access token, only if the logged in user is a dev.</returns>
    [HttpPut]
    public async Task<IActionResult> Put(string AuthCode) {
    Console.WriteLine(AuthCode);
      string[] DiscordShit = await IOFile.ReadAllLinesAsync("DiscordShit.txt");
      DOA2H.DOA2H DOA2H = new DOA2H.DOA2H(DiscordShit[0], DiscordShit[1]);
      Console.WriteLine($"https://{Request.Headers.Host}/News/Manage");
      ICallbackToken callbackToken = await DOA2H.GetAccessToken(AuthCode, $"https://localhost:7063/News/Manage");
      DOA2H.SetBearerHeader((CallbackToken)callbackToken);
      CallbackUser? user = await DOA2H.GetCurrentUser();
      if (Program.LoginKeys.ContainsKey(ulong.Parse(user.User.Id))) Program.LoginKeys.Remove(ulong.Parse(user.User.Id));
      string random = Guid.NewGuid().ToString();
      ulong nut;
      ulong.TryParse(user.User.Id, out nut);
      Program.LoginKeys.Add(nut, random);

      //  TODO: Force fetch app for Team members
      await DOA2H.ForceFetchApp();

      return Ok(random);
    }
    /// <summary>
    /// Exists to check validity of access token.
    /// </summary>
    /// <returns>A bool to show if the token is still valid.</returns>
    [HttpGet("AccessToken")]
    public async Task<bool> LoginWithAccessToken(string AccessToken) {
      if (Program.LoginKeys.Where(x => x.Value == AccessToken).Count() > 0)
      {
        return true;
      }
      else return false;
    }
  }
}
