using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DOA2H
{
  public class CallbackToken : ICallbackToken
  {
    [JsonPropertyName("access_token")]
    public string Access_Token { get; set; }
    [JsonPropertyName("expires_in")]
    public int Expires_In { get; set; }
    [JsonPropertyName("refresh_token")]
    public string Refresh_Token { get; set; }
    [JsonPropertyName("scope")]
    public string Scope { get; set; }
    [JsonPropertyName("token_type")]
    public string Token_Type { get; set; }

    public CallbackToken(string access_token, int expires_in, string refresh_token, string scope, string token_type)
    {
      this.Access_Token = access_token;
      this.Expires_In = expires_in;
      this.Refresh_Token = refresh_token;
      this.Scope = scope;
      this.Token_Type = token_type;
    }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }
}
