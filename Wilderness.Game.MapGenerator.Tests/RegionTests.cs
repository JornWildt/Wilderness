using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Wilderness.Game.MapGenerator.Tests
{
  [TestFixture]
  public class RegionTests
  {
    [Test]
    public void CanCalculateRegionIndex()
    {
      Assert.AreEqual(-3, TiledRegion<int>.GetRegionIndex(-11, 5));
      Assert.AreEqual(-2, TiledRegion<int>.GetRegionIndex(-10, 5));
      Assert.AreEqual(-2, TiledRegion<int>.GetRegionIndex(-9, 5));
      Assert.AreEqual(-1, TiledRegion<int>.GetRegionIndex(-5, 5));
      Assert.AreEqual(-1, TiledRegion<int>.GetRegionIndex(-4, 5));
      Assert.AreEqual(-1, TiledRegion<int>.GetRegionIndex(-3, 5));
      Assert.AreEqual(-1, TiledRegion<int>.GetRegionIndex(-2, 5));
      Assert.AreEqual(-1, TiledRegion<int>.GetRegionIndex(-1, 5));
      Assert.AreEqual(0, TiledRegion<int>.GetRegionIndex(0, 5));
      Assert.AreEqual(0, TiledRegion<int>.GetRegionIndex(1, 5));
      Assert.AreEqual(0, TiledRegion<int>.GetRegionIndex(2, 5));
      Assert.AreEqual(0, TiledRegion<int>.GetRegionIndex(3, 5));
      Assert.AreEqual(0, TiledRegion<int>.GetRegionIndex(4, 5));
      Assert.AreEqual(1, TiledRegion<int>.GetRegionIndex(5, 5));
      Assert.AreEqual(1, TiledRegion<int>.GetRegionIndex(9, 5));
      Assert.AreEqual(2, TiledRegion<int>.GetRegionIndex(10, 5));
    }
  }
}
