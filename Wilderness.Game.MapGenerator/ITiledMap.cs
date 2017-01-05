namespace Wilderness.Game.MapGenerator
{
  public interface ITiledMap<T>
    where T : struct
  {
    /// <summary>
    /// Size of tiles in game distance unit.
    /// </summary>
    double TileSize { get; }

    /// <summary>
    /// Access tiles by tile index.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    Tile<T> this[int x, int y] { get; set; }

    /// <summary>
    /// Access tiles by game distance unit.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    Tile<T> this[double x, double y] { get; set; }
  }
}
