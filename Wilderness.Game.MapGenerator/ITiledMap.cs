﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilderness.Game.MapGenerator
{
  public interface ITiledMap<T>
    where T : struct
  {
    int Width { get; }

    int Height { get; }

    Tile<T> this[int x, int y] { get; set; }
  }
}