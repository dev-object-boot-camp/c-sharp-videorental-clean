using System.Web.Mvc;

namespace video_rental.Filters
{
    public class LoginFilter : IActionFilter
    {
        public const string VideoRentalcookie = "VideoRentalCookie";

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower().Equals("login")) return;
            var videoRentalCookie = filterContext.RequestContext.HttpContext.Request.Cookies.Get(VideoRentalcookie);
            if (videoRentalCookie == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}