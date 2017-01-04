using NUnit.Framework;
using Wilderness.Game.MapGenerator.TileTypes;

namespace Wilderness.Game.MapGenerator.Tests
{
  [TestFixture]
  public class InMemoryTiledMapTests
  {
    [Test]
    public void CanDoBasicWorkWithMap()
    {
      // Arrange
      InMemoryTiledMap<int> map = new InMemoryTiledMap<int>(50, 10, 8, null);

      // Act
      map[0, 0] = new Tile<int>(10);
      map[0, 1] = new Tile<int>(20);
      map[0, -1] = new Tile<int>(30);
      map[1, 0] = new Tile<int>(40);
      map[1, 1] = new Tile<int>(50);
      map[1, -1] = new Tile<int>(60);
      map[-1, 0] = new Tile<int>(70);
      map[-1, 1] = new Tile<int>(80);
      map[-1, -1] = new Tile<int>(90);

      map[9, 0] = new Tile<int>(11);
      map[9, 9] = new Tile<int>(21);
      map[9, -9] = new Tile<int>(31);
      map[10, 0] = new Tile<int>(41);
      map[10, 10] = new Tile<int>(51);
      map[10, -10] = new Tile<int>(61);
      map[-10, 0] = new Tile<int>(71);
      map[-10, 10] = new Tile<int>(81);
      map[-10, -10] = new Tile<int>(91);

      Assert.AreEqual(10, map[0, 0].Content);
      Assert.AreEqual(20, map[0, 1].Content);
      Assert.AreEqual(30, map[0, -1].Content);
      Assert.AreEqual(40, map[1, 0].Content);
      Assert.AreEqual(50, map[1, 1].Content);
      Assert.AreEqual(60, map[1, -1].Content);
      Assert.AreEqual(70, map[-1, 0].Content);
      Assert.AreEqual(80, map[-1, 1].Content);
      Assert.AreEqual(90, map[-1, -1].Content);

      Assert.AreEqual(11, map[9, 0].Content);
      Assert.AreEqual(21, map[9, 9].Content);
      Assert.AreEqual(31, map[9, -9].Content);
      Assert.AreEqual(41, map[10, 0].Content);
      Assert.AreEqual(51, map[10, 10].Content);
      Assert.AreEqual(61, map[10, -10].Content);
      Assert.AreEqual(71, map[-10, 0].Content);
      Assert.AreEqual(81, map[-10, 10].Content);
      Assert.AreEqual(91, map[-10, -10].Content);
    }



    class ModulaMapGanerator : ITiledMapGenerator<int>
    {
      public void Initialize(TiledRegion<int> region)
      {
        for (int x = region.OffsetX; x < region.MaxX; ++x)
        {
          for (int y = region.OffsetY; y < region.MaxY; ++y)
          {
            region[x, y] = new Tile<int>(((x + y) % 2 == 0 ? (TileType)ForrestTile.Instance : (TileType)WaterTile.Instance), 0);
          }
        }
      }
    }


    [Test]
    public void CanUseMapGenerator()
    {
      // Arrange
      ITiledMapGenerator<int> generator = new ModulaMapGanerator();
      InMemoryTiledMap<int> map = new InMemoryTiledMap<int>(50, 10, 8, generator);

      // Act
      map[5, 5] = new Tile<int>(11);
      map[-5, -5] = new Tile<int>(12);

      // Assert
      Assert.AreEqual(ForrestTile.Instance, map[0, 0].Type);
      Assert.AreEqual(WaterTile.Instance, map[0, 1].Type);
      Assert.AreEqual(WaterTile.Instance, map[1, 0].Type);
      Assert.AreEqual(ForrestTile.Instance, map[1, 1].Type);
      Assert.IsNull(map[5, 5].Type);
      Assert.IsNull(map[-5, -5].Type);

      // Act+Assert
      Assert.AreEqual(ForrestTile.Instance, map[1123, -23].Type);
      Assert.AreEqual(WaterTile.Instance, map[1124, -23].Type);
    }
  }
}
