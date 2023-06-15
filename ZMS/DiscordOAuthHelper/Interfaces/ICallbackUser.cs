using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA2H
{
  public interface ICallbackUser
  {
    public Application Application { get; }
    public string[] Scopes { get; }
    public string expires { get; }
    public User User { get; }
  }
}
