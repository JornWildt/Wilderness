﻿namespace Wilderness.Game.Core
{
  public class Component : IComponent
  {
    public EntityId EntityId { get; private set; }

    public Component(EntityId entityId)
    {
      EntityId = entityId;
    }
  }
}
