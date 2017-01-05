﻿using System;
using System.Windows;
using Wilderness.Game.Blueprint.Physics;
using Wilderness.Game.Blueprint.Rendering;
using Wilderness.Game.Core;

namespace Wilderness.Game.Blueprint.EntityFactories
{
  public static class ExplosionFactory
  {
    public static Entity BuildExplosion(Point pos)
    {
      EntityId id = EntityId.NewId();

      return new Entity(
        id,
        new IComponent[3]
        {
          new PhysicsComponent(id, pos, new Vector(0,0)),
          new VisualComponent(id, "T3"),
          new TimedComponent(id, TimeSpan.FromSeconds(4))
        });
    }
  }
}
