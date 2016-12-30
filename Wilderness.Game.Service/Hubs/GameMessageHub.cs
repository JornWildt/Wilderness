using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Wilderness.Game.Service.Hubs
{
  public class GameMessageHub : Hub
  {
    public async Task Send(string name, string message)
    {
      await SendMessage(name, message);
    }


    internal static async Task SendMessage(string name, string message)
    {
      IHubContext context = GlobalHost.ConnectionManager.GetHubContext<GameMessageHub>();
      await context.Clients.All.addNewMessageToPage(name, message);
      return;
    }
  }
}