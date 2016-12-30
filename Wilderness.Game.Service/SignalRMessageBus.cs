using System;
using System.Threading.Tasks;
using Wilderness.Game.Core.Common;
using Wilderness.Game.Service.Hubs;

namespace Wilderness.Game.Service
{
  public class SignalRMessageBus : IMessageBus
  {
    public async Task Publish(string channel, object msg)
    {
      Console.WriteLine($"[{channel}] {msg}");
      await GameMessageHub.SendMessage(channel, msg);
    }
  }
}
