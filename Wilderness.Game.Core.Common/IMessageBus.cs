using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilderness.Game.Core.Common
{
  public interface IMessageBus
  {
    Task Publish(string channel, object msg);
  }
}
