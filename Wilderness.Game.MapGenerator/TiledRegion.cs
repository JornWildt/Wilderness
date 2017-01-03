using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;

namespace Wilderness.Game.MapGenerator
{
  public class TiledRegion<T>
    where T : struct
  {
    public int OffsetX { get; protected set; }

    public int OffsetY { get; protected set; }

    public int Width { get; protected set; }

    public int Height { get; protected set; }

    public int MaxX { get; protected set; }

    public int MaxY { get; protected set; }

    protected Tile<T>[,] Tiles { get; set; }


    public TiledRegion(int offsetX, int offsetY, int width, int height)
    {
      Condition.Requires(width, nameof(width)).IsGreaterThan(0);
      Condition.Requires(height, nameof(height)).IsGreaterThan(0);

      OffsetX = offsetX;
      OffsetY = offsetY;
      Width = width;
      Height = height;
      MaxX = OffsetX + Width;
      MaxY = OffsetY + Height;

      Tiles = new Tile<T>[Width, Height];
    }

    public Tile<T> this[int x, int y]
    {
      get
      {
        VerifyCoordinatesInRange(x, y);
        return Tiles[x - OffsetX, y - OffsetY];
      }

      set
      {
        VerifyCoordinatesInRange(x, y);
        Tiles[x - OffsetX, y - OffsetY] = value;
      }
    }


    protected void VerifyCoordinatesInRange(int x, int y)
    {
      if (x < OffsetX || x >= MaxX || y < OffsetY || y >= MaxY)
        throw new ArgumentException($"The coordinate ({x},{y}) is out of range for tiled region ({OffsetX},{OffsetY};{MaxX},{MaxY}).");
    }


    public static int GetRegionIndex(int pos, int size) => ((pos < 0 ? pos-size+1 : pos) / size);
  }
}
