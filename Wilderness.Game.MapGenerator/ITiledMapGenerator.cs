using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilderness.Game.MapGenerator
{
  public interface ITiledMapGenerator<T>
    where T : struct
  {
    void Initialize(TiledRegion<T> region);
  }
}
