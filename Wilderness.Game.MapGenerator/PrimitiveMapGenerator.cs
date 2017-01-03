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
  }
}
