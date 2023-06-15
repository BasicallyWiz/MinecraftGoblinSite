using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA2H
{
  public interface ICallbackRefreshToken
  {
    public CallbackToken Result { get; set; }
    public int Id { get; set; }
    public object? Exception { get; set; }
    public int Status { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsCompletedSuccessfully { get; set; }
    public int CreationOptions { get; set; }
    public object? AsyncState { get; set; }
    public bool IsFaulted { get; set; }
  }
}
