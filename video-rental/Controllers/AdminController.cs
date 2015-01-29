using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video_rental.Models.Repositories;

namespace video_rental.Controllers
{
    public class AdminController : Controller
    {
        private ICustomerRepository customerRepository;

        public AdminController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        //
        // GET: /Admin/

        [HttpGet]
        public ActionResult Index()
        {
            return View(customerRepository.SelectAll());
        }
    }
}
