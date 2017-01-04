namespace Wilderness.Game.MapGenerator
{
  public interface ITiledMap<T>
    where T : struct
  {
    double TileSize { get; }
    Tile<T> this[int x, int y] { get; set; }
  }
}
