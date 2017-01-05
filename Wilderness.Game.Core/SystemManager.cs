using System.Collections.Generic;

namespace Wilderness.Game.Core
{
  public class SystemManager
  {
    protected List<ISystem> Systems { get; set; }


    public SystemManager()
    {
      Systems = new List<ISystem>();
    }


    public void RegisterSystem(ISystem system)
    {
      Systems.Add(system);
    }


    public IEnumerable<ISystem> AllSystems
    {
      get
      {
        return Systems;
      }
    }
  }
}
