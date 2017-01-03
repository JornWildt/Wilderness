using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wilderness.Game.MapGenerator;

namespace Wilderness.Game.MapGenerator.Tests
{
  [TestFixture]
  public class InMemoryTiledMapTests
  {
    [Test]
    public void CanDoBasicWorkWithMap()
    {
      // Arrange
      InMemoryTiledMap<int> map = new InMemoryTiledMap<int>(10, 8);

      // Act
      map[0, 0] = 10;
      map[0, 1] = 20;
      map[0, -1] = 30;
      map[1, 0] = 40;
      map[1, 1] = 50;
      map[1, -1] = 60;
      map[-1, 0] = 70;
      map[-1, 1] = 80;
      map[-1, -1] = 90;

      map[9, 0] = 11;
      map[9, 9] = 21;
      map[9, -9] = 31;
      map[10, 0] = 41;
      map[10, 10] = 51;
      map[10, -10] = 61;
      map[-10, 0] = 71;
      map[-10, 10] = 81;
      map[-10, -10] = 91;

      Assert.AreEqual(10, map[0, 0]);
      Assert.AreEqual(20, map[0, 1]);
      Assert.AreEqual(30, map[0, -1]);
      Assert.AreEqual(40, map[1, 0]);
      Assert.AreEqual(50, map[1, 1]);
      Assert.AreEqual(60, map[1, -1]);
      Assert.AreEqual(70, map[-1, 0]);
      Assert.AreEqual(80, map[-1, 1]);
      Assert.AreEqual(90, map[-1, -1]);

      Assert.AreEqual(11, map[9, 0]);
      Assert.AreEqual(21, map[9, 9]);
      Assert.AreEqual(31, map[9, -9]);
      Assert.AreEqual(41, map[10, 0]);
      Assert.AreEqual(51, map[10, 10]);
      Assert.AreEqual(61, map[10, -10]);
      Assert.AreEqual(71, map[-10, 0]);
      Assert.AreEqual(81, map[-10, 10]);
      Assert.AreEqual(91, map[-10, -10]);
    }
  }
}
