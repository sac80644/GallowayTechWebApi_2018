using System.Web;
using System.Web.Mvc;

namespace GallowayTechWebApi_2018
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
