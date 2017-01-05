using System.Collections.Generic;

namespace Wilderness.Game.Core
{
  public interface IDependencyContainer
  {
    T Resolve<T>();

    IEnumerable<T> ResolveAll<T>();
  }
}
