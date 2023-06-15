using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZMS.Shared.News
{
/// <summary>
/// Profile class for a user.
/// </summary>
/// <remarks>
/// Users will only be members of the dev team, those who should be able to write articles.
/// </remarks>
  [JsonSerializable(typeof(Profile))]
  public class Profile
  {
    /// <summary>
    /// Discord id of this user.
    /// </summary>
    public ulong Id { get; set; }
    /// <summary>
    /// Discord display name of this user.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Discord Avatar hash of this user.
    /// </summary>
    public string Avatar { get; set; }
    public ulong ArticleCount { get; set; }
    /// <summary>
    /// The content of the /Profile/ page for this user.
    /// </summary>
    /// <remarks>
    /// Should be written in markdown.
    /// </remarks>
    public string? Content { get; set; }

    /// <param name="Id">Discord id of user.</param>
    /// <param name="Name">Discord display name of user.</param>
    /// <param name="Avatar">Discord avatar hash of user</param>
    /// <param name="ArticleCount">Amount of articles this user has taken part of.</param>
    /// <param name="Content">Markdown for this user's /Profile/ page.</param>
    [JsonConstructor]
    public Profile(ulong Id, string Name, string Avatar, ulong ArticleCount, string? Content)
    {
      this.Id = Id;
      this.Name = Name;
      this.Avatar = Avatar;
      this.ArticleCount = ArticleCount;
      this.Content = Content;
    }

    public string GetAvatarUrl()
    {
      return $"https://cdn.discordapp.com/avatars/{Id}/{Avatar}.png";
    }
  }
}
