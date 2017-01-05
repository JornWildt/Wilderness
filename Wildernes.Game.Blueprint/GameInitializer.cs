using Wildernes.Game.Blueprint.EntityFactories;
using Wilderness.Game.Core;

namespace Wildernes.Game.Blueprint
{
  public class GameInitializer
  {
    #region Dependencies

    public IEntityRepository Entitys { get; set; }

    #endregion


    public void Initialize()
    {
      Entity bear1 = BearFactory.BuildABear("Blackie", 0, 0);
      Entity bear2 = BearFactory.BuildABear("Brownie", 10, 10);
      Entity bear3 = BearFactory.BuildABear("Beast", -10, -10);
      Entitys.AddEntity(bear1);
      Entitys.AddEntity(bear2);
      Entitys.AddEntity(bear3);

      Entity player = PlayerFactory.BuildPlayer("Borg");
      Entitys.AddEntity(player);
    }
  }
}
