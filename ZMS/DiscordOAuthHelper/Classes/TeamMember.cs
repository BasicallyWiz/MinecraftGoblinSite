using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DOA2H
{
  [JsonSerializable(typeof(TeamMember))]
  public class TeamMember : ITeamMember
  {
    [JsonPropertyName("membership_state")]
    public int Membership_State { get; }
    [JsonPropertyName("permissions")]
    public string[] Permissions { get; }
    [JsonPropertyName("team_id")]
    public string Team_Id { get; }
    [JsonPropertyName("user")]
    public IUser User { get; }
  
    [JsonConstructor]
    public TeamMember(int Membership_State, string[] Permissions, string Team_Id, IUser User) {
      this.Membership_State = Membership_State;
      this.Permissions = Permissions;
      this.Team_Id = Team_Id;
      this.User = User;
    }
  }
}
