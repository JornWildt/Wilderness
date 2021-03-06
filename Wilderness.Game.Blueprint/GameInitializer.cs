﻿using CuttingEdge.Conditions;
using Wilderness.Game.Blueprint.EntityFactories;
using Elfisk.ECS.Core;

namespace Wilderness.Game.Blueprint
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

      entities.AddEntity(BearFactory.BuildABear("Blop", -10, 10));
      entities.AddEntity(BearFactory.BuildABear("Rolph", 10, -10));

      Entity player = PlayerFactory.BuildPlayer("Borg");
      entities.AddEntity(player);
    }
  }
}
