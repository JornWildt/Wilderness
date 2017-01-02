using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elfisk.Commons;

namespace Wilderness.Game.Web
{
  public static class WebAppSettings
  {
    public static readonly AppSetting<string> SignalRBaseUrl = new AppSetting<string>("Web.SignalRBaseUrl");
  }
}