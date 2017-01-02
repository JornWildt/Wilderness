using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;

namespace Wilderness.Game.MapGenerator
{
  public class InMemoryTiledMap<T> 
    : ITiledMap<T> where T : struct
  {
    protected int XSize;
    protected int YSize;

    protected Tile<T>[,] Tiles { get; set; }

    public InMemoryTiledMap(int xsize, int ysize)
    {
      Condition.Requires(xsize, nameof(xsize)).IsGreaterThan(0);
      Condition.Requires(ysize, nameof(ysize)).IsGreaterThan(0);

      XSize = xsize;
      YSize = ysize;

      Tiles = new Tile<T>[XSize, YSize];
    }

    public int Width
    {
      get
      {
        return XSize;
      }
    }

    public int Height
    {
      get
      {
        return YSize;
      }
    }


    public Tile<T> this[int x, int y]
    {
      get
      {
        return Tiles[x+XSize/2, y+YSize/2];
      }

      set
      {
        Tiles[x + XSize / 2, y + YSize / 2] = value;
      }
    }
  }
}
