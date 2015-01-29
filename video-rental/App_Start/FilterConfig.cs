using System.Web.Mvc;
using video_rental.Filters;

namespace video_rental
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginFilter());
        }
    }
}