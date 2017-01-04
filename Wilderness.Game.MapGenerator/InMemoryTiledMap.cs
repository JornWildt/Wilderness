using System.Collections.Generic;
using CuttingEdge.Conditions;

namespace Wilderness.Game.MapGenerator
{
  public class InMemoryTiledMap<T> 
    : ITiledMap<T> where T : struct
  {
    public double TileSize { get; protected set; }

    public int RegionWidth { get; protected set; }

    public int RegionHeight { get; protected set; }

    // FIXME: not the best performing infinite array of regions
    protected Dictionary<string, TiledRegion<T>> TileRegions { get; set; }

    protected ITiledMapGenerator<T> MapGenerator { get; set; }


    public InMemoryTiledMap(double tileSize, int regionWidth, int regionHeight, ITiledMapGenerator<T> generator)
    {
      Condition.Requires(tileSize, nameof(tileSize)).IsGreaterThan(0.0);
      Condition.Requires(regionWidth, nameof(regionWidth)).IsGreaterThan(0);
      Condition.Requires(regionHeight, nameof(regionHeight)).IsGreaterThan(0);

      TileSize = tileSize;
      RegionWidth = regionWidth;
      RegionHeight = regionHeight;
      TileRegions = new Dictionary<string, TiledRegion<T>>();
      MapGenerator = generator;
    }


    public Tile<T> this[int x, int y]
    {
      get
      {
        TiledRegion<T> region = GetRegion(x, y);
        return region[x, y];
      }

      set
      {
        TiledRegion<T> region = GetRegion(x, y);
        region[x, y] = value;
        //region.SetTile(x, y, value);
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

      MapGenerator?.Initialize(region);

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
