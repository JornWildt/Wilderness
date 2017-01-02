using Elfisk.Commons;

namespace Wilderness.Game.Service
{
  public static class ServiceAppSettings
  {
    public static readonly AppSetting<string> SignalRUrl = new AppSetting<string>("Service.SignalRUrl");
  }
}
