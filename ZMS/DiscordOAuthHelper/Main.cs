using DOA2H;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
///<summary>
/// 
///</summary>
namespace DOA2H
{
  public class DOA2H
  {
    public HttpClient Client { get; set; }
    public HttpClient BotClient { get; set; }
    public string Id { get; }
    public string ClientSecret { get; }
    public DOA2H(string ClientId, string ClientSecret) {
      Client = new HttpClient();

      this.Id = ClientId;
      this.ClientSecret = ClientSecret;
    }

    /// <summary>
    /// Gets an access token from Discord's OAuth2 API, using the provided authorization code.
    /// </summary>
    /// <param name="AuthCode">Authorization code provided by the user.</param>
    /// <param name="RedirectUri">Redirect Uri to inform discord that the redirect uri the client was sent to is legitemate.</param>
    /// <remarks>In a process of getting user OAuth, this is the first step.</remarks>
    /// <returns><see cref="ICallbackToken"/> containing a partial <see cref="User"/> object.</returns>
    public async Task<ICallbackToken> GetAccessToken(string AuthCode, string RedirectUri) {
      
      var form = new Dictionary<string, string>
        {
          { "client_id", Id },
          { "client_secret", ClientSecret },
          { "grant_type", GrantType.AuthorizationCode },
          { "code", AuthCode },
          { "redirect_uri", RedirectUri },
        };

      HttpResponseMessage response = await Client.PostAsync("https://discord.com/api/v8/oauth2/token", new FormUrlEncodedContent(form));

      if (!response.IsSuccessStatusCode) Console.WriteLine(await response.Content.ReadAsStringAsync());
      return JsonSerializer.Deserialize<CallbackToken>(await response.Content.ReadAsStringAsync());
    }
    /// <summary>
    /// Sets the client's default request header to include a bearer token for access to the user given in the <paramref name="CallbackToken"/> parameter.
    /// </summary>
    /// <param name="CallbackToken">The <see cref="CallbackToken"/> recieved earlier using the <see cref="GetAccessToken(string, string)"/> method.</param>
    /// <returns></returns>
    public async Task SetBearerHeader(CallbackToken CallbackToken) {
      Client.DefaultRequestHeaders.Remove("Authorization");
      Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {CallbackToken.Access_Token}");
    }
    /// <summary>
    /// Gets basic data on the user this method has been run for.
    /// </summary>
    /// <remarks>
    /// Requires that this client has already undergone <see cref="SetBearerHeader(CallbackToken)"/>.
    /// </remarks>
    /// <returns>A <see cref="CallbackUser"/> object, containing data on the Discord user</returns>.
    public async Task<CallbackUser>? GetCurrentUser()
    {
      HttpResponseMessage response = await Client.GetAsync("https://discord.com/api/v10/oauth2/@me");

      if (!response.IsSuccessStatusCode) Console.WriteLine(await response.Content.ReadAsStringAsync());
      if (!response.IsSuccessStatusCode) return null;
      CallbackUser user = JsonSerializer.Deserialize<CallbackUser>(await response.Content.ReadAsStringAsync());
      return user;
    }
    
    /// <summary>
    /// Uses a bot account to fetch the app's data by qurying with the app id instead of /@me to ensure a full <see cref="Application"/> object is returned."/>
    /// </summary>
    /// <returns></returns>
    public async Task ForceFetchApp() {
      BotClient = new HttpClient();

    }
    /*
    public static async Task<User>? ForceFetchUser(string UserId, string BotToken) 
    {
      Console.WriteLine("Force-fetching user...");
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Add("Authorization", $"Bot {BotToken}");
      var response = await client.GetAsync($"https://discord.com/api/v8/users/{UserId}");
      if (!response.IsSuccessStatusCode) return null;
      return JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync());
    }
    */
  }
}