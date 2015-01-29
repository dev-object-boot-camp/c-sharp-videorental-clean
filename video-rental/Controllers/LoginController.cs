using System;
using System.Web;
using System.Web.Mvc;
using video_rental.Filters;
using video_rental.Models.Comparer;
using video_rental.Models.Repositories;

namespace video_rental.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public LoginController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View(customerRepository.SelectAll(new CustomersOrderedByNameComparator()));
        }

        [HttpPost]
        public ActionResult Index(string userName)
        {
            var userCookie = new HttpCookie(LoginFilter.VideoRentalcookie,userName);
            HttpContext.Response.Cookies.Add(userCookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (Request.Cookies[LoginFilter.VideoRentalcookie] != null)
            {
                var myCookie = new HttpCookie(LoginFilter.VideoRentalcookie)
                {
                    Expires = DateTime.Now.AddDays(-1d)
                };
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
