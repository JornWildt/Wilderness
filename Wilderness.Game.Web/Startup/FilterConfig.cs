using System.Web;
using System.Web.Mvc;

namespace Wilderness.Game.Web.Startup
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
