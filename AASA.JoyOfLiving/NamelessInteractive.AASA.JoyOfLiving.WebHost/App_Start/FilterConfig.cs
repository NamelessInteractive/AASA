using System.Web;
using System.Web.Mvc;

namespace NamelessInteractive.AASA.JoyOfLiving.WebHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
