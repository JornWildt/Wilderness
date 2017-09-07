using Elfisk.Commons;

namespace Wilderness.Game.Service
{
  public static class ServiceAppSettings
  {
    /// <summary>
    /// Size (width/height) of each tile - in meters.
    /// </summary>
    public static readonly AppSetting<int> MapTileSize = new AppSetting<int>("Service.MapTileSize", 10);

    /// <summary>
    /// Size (width/height) of each tile region - in number of tiles.
    /// </summary>
    public static readonly AppSetting<int> MapRegionSize = new AppSetting<int>("Service.MapRegionSize", 100);

    public static readonly AppSetting<string> SignalRUrl = new AppSetting<string>("Service.SignalRUrl");
  }
}
