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
      }
      else if (k % 2 == 0 && l % 2 == 1)
      {
      }
      else
      {
      }
    }


    private void Initialize(TiledRegion<T> region, int distance, ForrestTile tile)
    {
      for (int x = region.OffsetX; x < region.MaxX; x += distance)
      {
        for (int y = region.OffsetY; y < region.MaxY; y += distance)
        {
          region[x, y] = new Tile<T> { Type = tile };
        }
      }
    }
  }
}
