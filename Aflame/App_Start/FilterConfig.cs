using System.Web;
using System.Web.Mvc;

namespace Aflame
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // we made it here to be Globaly at all App and be Authorized,
            filters.Add(new RequireHttpsAttribute()); // to can't access site with http
        }
    }
}
