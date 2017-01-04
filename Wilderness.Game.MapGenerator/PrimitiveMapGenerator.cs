using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wilderness.Game.MapGenerator.TileTypes;

namespace Wilderness.Game.MapGenerator
{
  public class PrimitiveMapGenerator<T> : ITiledMapGenerator<T>
    where T : struct
  {
    public void Initialize(TiledRegion<T> region)
    {
      int k = region.OffsetX / region.Width;
      int l = region.OffsetY / region.Height;

      if (k % 2 == 0 && l % 2 == 0)
      {
        Initialize(region, 2, ForrestTile.Instance);
      }
      else if (k % 2 == 1 && l % 2 == 0)
      {
        Initialize(region, 2, WaterTile.Instance);
      }
      else if (k % 2 == 0 && l % 2 == 1)
      {
        Initialize(region, 3, ForrestTile.Instance);
      }
      else
      {
        Initialize(region, 3, WaterTile.Instance);
      }
    }


    private void Initialize(TiledRegion<T> region, int distance, TileType tile)
    {
      for (int x = region.OffsetX; x < region.MaxX; ++x)
      {
        for (int y = region.OffsetY; y < region.MaxY; ++y)
        {
          if (x % distance == 0 && y % distance == 0)
            region[x, y] = new Tile<T>(tile, default(T));
          else
            region[x, y] = new Tile<T>(GrassTile.Instance, default(T));
        }
      }
    }
  }
}
