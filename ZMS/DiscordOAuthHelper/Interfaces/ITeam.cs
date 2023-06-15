using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA2H
{
  public interface ITeam
  {
    string Icon { get; }
    string Id { get; }
    //TODO: Create a member class, and have this parameter be an array of members.
    ITeamMember[] Members { get; }
    string Name { get; }
    string Owner_User_Id { get; }
  }
}
