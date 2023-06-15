using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA2H
{
  public interface ITeamMember
  {
    int Membership_State { get; }
    string[] Permissions { get; }
    string Team_Id { get; }
    IUser User { get; }
  }
}
