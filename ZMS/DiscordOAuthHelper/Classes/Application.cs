using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DOA2H
{
  /// <summary>
  /// The application object
  /// </summary>
  public class Application : IApplication
  {
    /// <summary>
    /// The id of the app.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; }
    /// <summary>
    /// The name of the app.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; }
    /// <summary>
    /// The icon hash of the app.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; }
    [JsonPropertyName("description")]
    public string Description { get; }
    [JsonPropertyName("summary")]
    public string Summary { get; }
    [JsonPropertyName("type")]
    public string? Type { get; }
    [JsonPropertyName("hook")]
    public bool Hook { get; }
    [JsonPropertyName("custom_install_url")]
    public string Custom_Install_Url { get; }
    [JsonPropertyName("verify_key")]
    public string Verify_Key { get; }
    [JsonPropertyName("rpc_origins")]
    public string[]? Rpc_Origins { get;  }
    [JsonPropertyName("bot_public")]
    public bool Bot_Public { get; }
    [JsonPropertyName("bot_require_code_grant")]
    public bool Bot_Require_Code_Grant { get; }
    [JsonPropertyName("terms_of_service_url")]
    public string? Terms_Of_Service_Url { get; }
    [JsonPropertyName("privacy_policy_url")]
    public string? Privacy_Policy_Url { get; }
    [JsonPropertyName("owner_id")]
    public string? Owner_Id { get; }
    [JsonPropertyName("team")]
    public string? Team { get; }
    [JsonPropertyName("guild_id")]
    public string? Guild_Id { get; }
    [JsonPropertyName("primary_sku_id")]
    public string? Primary_Sku_Id { get; }
    [JsonPropertyName("slug")]
    public string? Slug { get; }
    [JsonPropertyName("cover_image")]
    public string? Cover_Image { get; }
    [JsonPropertyName("flags")]
    public string? Flags { get; }
    [JsonPropertyName("tags")]
    public string? Tags { get; }
    [JsonPropertyName("install_params")]
    public string? Install_Params { get; }
    [JsonPropertyName("role_connections_verification_url")]
    public string? Role_Connections_Verification_Url { get; }
  }
}
