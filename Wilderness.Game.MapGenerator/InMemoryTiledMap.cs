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
    public int RegionWidth { get; protected set; }

    public int RegionHeight { get; protected set; }

    protected Dictionary<string, TiledRegion<T>> TileRegions { get; set; }


    public InMemoryTiledMap(int regionWidth, int regionHeight)
    {
      Condition.Requires(regionWidth, nameof(regionWidth)).IsGreaterThan(0);
      Condition.Requires(regionHeight, nameof(regionHeight)).IsGreaterThan(0);

      RegionWidth = regionWidth;
      RegionHeight = regionHeight;
      TileRegions = new Dictionary<string, TiledRegion<T>>();
    }


    public T this[int x, int y]
    {
      get
      {
        TiledRegion<T> region = GetRegion(x, y);
        return region[x, y].Content;
      }

      set
      {
        TiledRegion<T> region = GetRegion(x, y);
        region.SetContent(x, y, value);
      }
    }


    protected TiledRegion<T> GetRegion(int x, int y)
    {
      string regionCacheKey = GenerateRegionCacheKey(x, y);
      if (!TileRegions.ContainsKey(regionCacheKey))
      {
        TiledRegion<T> region = BuildRegion(x, y);
        TileRegions[regionCacheKey] = region;
      }

      return TileRegions[regionCacheKey];
    }


    private TiledRegion<T> BuildRegion(int x, int y)
    {
      int rx = GetRegionX(x);
      int ry = GetRegionY(y);

      TiledRegion<T> region = new TiledRegion<T>(rx * RegionWidth, ry * RegionHeight, RegionWidth, RegionHeight);

      return region;
    }


    protected string GenerateRegionCacheKey(int x, int y)
    {
      int rx = GetRegionX(x);
      int ry = GetRegionY(y);

      return rx + "/" + ry;
    }


    protected int GetRegionX(int x) => TiledRegion<T>.GetRegionIndex(x, RegionWidth);


    protected int GetRegionY(int y) => TiledRegion<T>.GetRegionIndex(y, RegionHeight);
  }
}
