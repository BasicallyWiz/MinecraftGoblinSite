namespace DOA2H
{
  public interface IUser
  {
    public string Id { get; }
    public string Username { get; }
    public string Discriminator { get; }
    public string? Global_Name { get; }
    public string? Display_Name { get; }
    public string? Avatar { get; }
    bool Bot { get; }
    bool System { get; }
    bool MFA_Enabled { get; }
    string? Banner { get; }
    int? Accent_Color { get; }
    string Locale { get; }
    /// <summary>
    /// If user has verified their email.
    /// </summary>
    bool Verified { get; }
    string? Email { get; }
    int? Flags { get; }
    int? Premium_Type { get; }
    public string? Avatar_Decoration { get; }
    public int Public_Flags { get; }
  }
}
