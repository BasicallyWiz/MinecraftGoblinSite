using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA2H
{
  public interface IApplication
  {
    public string Id { get; }
    public string Name { get; }
    public string? Icon { get; }
    public string Description { get; }
    public string[]? Rpc_Origins { get; }
    public bool Bot_Public { get; }
    public bool Bot_Require_Code_Grant { get; }
    public string? Terms_Of_Service_Url { get; }
    public string? Privacy_Policy_Url { get; }
    public string? Owner_Id { get; }
    [Obsolete("Deprecated and will return null after Discord api version 11.")]
    public string? Summary { get; }
    public string Verify_Key { get; }
    public string? Team { get; }
    public string? Guild_Id { get; }
    public string? Primary_Sku_Id { get; }
    public string? Slug { get; }
    public string? Cover_Image { get; }
    public string? Flags { get; }
    public string? Tags { get; }
    public string? Install_Params { get; }
    public string? Custom_Install_Url { get; }
    public string? Role_Connections_Verification_Url { get; }
  }
}
