﻿using System;
using CuttingEdge.Conditions;

namespace Wilderness.Game.Core.GameEvents
{
  public class ActionEvent : IGameLoopEvent
  {
    Action F { get; set; }


    public ActionEvent(Action f)
    {
      Condition.Requires(f, nameof(f)).IsNotNull();
      F = f;
    }

    public void Invoke(GameEnvironment environment)
    {
      F();
    }
  }
}
