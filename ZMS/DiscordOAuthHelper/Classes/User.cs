using System.Text.Json.Serialization;

namespace DOA2H
{
  public class User : IUser
  {
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("username")]
    public string Username { get; }
    [JsonPropertyName("global_name")]
    public string? Global_Name { get; }
    [JsonPropertyName("display_name")]
    public string? Display_Name { get; }
    [JsonPropertyName("discriminator")]
    public string Discriminator { get; }
    [JsonPropertyName("avatar")]
    public string? Avatar { get; }
    [JsonPropertyName("bot")]
    public bool Bot { get; }
    [JsonPropertyName("system")]
    public bool System { get; }
    [JsonPropertyName("mfa_enabled")]
    public bool MFA_Enabled { get; }
    [JsonPropertyName("banner")]
    public string? Banner { get; }
    [JsonPropertyName("accent_color")]
    public int? Accent_Color { get; }
    [JsonPropertyName("locale")]
    public string? Locale { get; }
    [JsonPropertyName("verified")]
    public bool Verified { get; }
    [JsonPropertyName("email")]
    public string? Email { get; }
    [JsonPropertyName("flags")]
    public int? Flags { get; }
    [JsonPropertyName("premium_type")]
    public int? Premium_Type { get; }
    [JsonPropertyName("avatar_decoration")]
    public string? Avatar_Decoration { get; }
    [JsonPropertyName("public_flags")]
    public int Public_Flags { get; }
    public User(string id, string username, string? global_name, string? display_name, string discriminator, string? avatar, string? banner, int? accent_color, string? locale, string? email, int? flags, int? premium_type, string? avatar_decoration, int public_flags, bool bot = false, bool system = false, bool mfa_enabled = false, bool verified = false)
    {
      Id = id;
      Username = username;
      Global_Name = global_name;
      Display_Name = display_name;
      Discriminator = discriminator;
      Avatar = avatar;
      Banner = banner;
      Accent_Color = accent_color;
      Locale = locale;
      Verified = verified;
      Email = email;
      Flags = flags;
      Premium_Type = premium_type;
      Avatar_Decoration = avatar_decoration;
      Public_Flags = public_flags;
      Bot = bot;
      System = system;
      MFA_Enabled = mfa_enabled;
    }
  }
}
