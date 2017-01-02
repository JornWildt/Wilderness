using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilderness.Game.MapGenerator
{
  public class PrimitiveMapGenerator<T>
    where T : struct
  {
    protected ITiledMap<T> Map { get; set; }


    public PrimitiveMapGenerator(int xsize, int ysize)
    {
      Map = new InMemoryTiledMap<T>(xsize, ysize);
    }


    public ITiledMap<T> Generate()
    {
      for (int x = -Map.Width / 2; x < Map.Width / 2; ++x)
      {
        for (int y = -Map.Height / 2; y < Map.Height / 2; ++y)
        {
          Map[x, y] = new Tile<T> { Content = default(T), X = x, Y = y };
        }
      }

      return Map;
    }
  }
}
