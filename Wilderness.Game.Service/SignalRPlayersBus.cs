using System;
using System.Threading.Tasks;
using Wilderness.Game.Core;
using Wilderness.Game.Service.Hubs;

namespace Wilderness.Game.Service
{
  public class SignalRPlayersBus : IPlayersBus
  {
    public async Task Send(string player, object msg)
    {
      Console.WriteLine($"[{player}] {msg}");
      await GameMessageHub.SendMessage(player, msg);
    }
  }
}
