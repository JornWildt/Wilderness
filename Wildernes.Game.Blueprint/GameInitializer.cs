using CuttingEdge.Conditions;
using Wildernes.Game.Blueprint.EntityFactories;
using Wilderness.Game.Core;

namespace Wildernes.Game.Blueprint
{
  public static class GameInitializer
  {
    public static void Initialize(IEntityRepository entities)
    {
      Condition.Requires(entities, nameof(entities)).IsNotNull();

      Entity bear1 = BearFactory.BuildABear("Blackie", 0, 0);
      Entity bear2 = BearFactory.BuildABear("Brownie", 10, 10);
      Entity bear3 = BearFactory.BuildABear("Beast", -10, -10);
      entities.AddEntity(bear1);
      entities.AddEntity(bear2);
      entities.AddEntity(bear3);

      Entity player = PlayerFactory.BuildPlayer("Borg");
      entities.AddEntity(player);
    }
  }
}
