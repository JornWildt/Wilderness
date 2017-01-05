using Castle.Windsor;
using CuttingEdge.Conditions;
using Wilderness.Game.Core;

namespace Wilderness.Game.Service
{
  public class CastleDependencyContainer : IDependencyContainer
  {
    protected IWindsorContainer Container { get; set; }


    public CastleDependencyContainer(IWindsorContainer container)
    {
      Condition.Requires(container, nameof(container)).IsNotNull();
      Container = container;
    }


    public T Resolve<T>()
    {
      return Container.Resolve<T>();
    }
  }
}
