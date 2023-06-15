using System.Text.Json.Serialization;

namespace DOA2H
{
  [JsonSerializable(typeof(ITeam))]
  public class Team : ITeam
  {
    [JsonPropertyName("icon")]
    public string Icon { get; }
    [JsonPropertyName("id")]
    public string Id { get; }
    [JsonPropertyName("members")]
    public ITeamMember[] Members { get; }
    [JsonPropertyName("name")]
    public string Name { get; }
    [JsonPropertyName("owner_user_id")]
    public string Owner_User_Id { get; }

    [JsonConstructor]
    public Team(string Icon, string Id, ITeamMember[] Members, string Name, string Owner_User_Id)
    {
      this.Icon = Icon;
      this.Id = Id;
      this.Members = Members;
      this.Name = Name;
      this.Owner_User_Id = Owner_User_Id;
    }
  }
}
