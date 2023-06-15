using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace DOA2H
{
  public class CallbackRefreshToken : ICallbackRefreshToken
  {
    [JsonPropertyName("Result")]
    public CallbackToken Result { get; set; }
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Exception")]
    public object? Exception { get; set; }
    [JsonPropertyName("Status")]
    public int Status { get; set; }
    [JsonPropertyName("IsCancelled")]
    public bool IsCancelled { get; set; }
    [JsonPropertyName("IsCompleted")]
    public bool IsCompleted { get; set; }
    [JsonPropertyName("IsCompletedSuccessfully")]
    public bool IsCompletedSuccessfully { get; set; }
    [JsonPropertyName("CreationOptions")]
    public int CreationOptions { get; set; }
    [JsonPropertyName("AsyncState")]
    public object? AsyncState { get; set; }
    [JsonPropertyName("IsFaulted")]
    public bool IsFaulted { get; set; }

    public CallbackRefreshToken(CallbackToken Result, int Id, object? Exception, int Status, bool IsCancelled, bool IsCompleted, bool IsCompletedSuccessfully, int CreationOptions, object? AsyncState, bool IsFaulted)
    {
      this.Result = Result;
      this.Id = Id;
      this.Exception = Exception;
      this.Status = Status;
      this.IsCancelled = IsCancelled;
      this.IsCompleted = IsCompleted;
      this.IsCompletedSuccessfully = IsCompletedSuccessfully;
      this.CreationOptions = CreationOptions;
      this.AsyncState = AsyncState;
      this.IsFaulted = IsFaulted;
    }
  }
}
