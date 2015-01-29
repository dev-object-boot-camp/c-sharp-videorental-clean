using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video_rental.Filters;
using video_rental.Models;
using video_rental.Models.Repositories;

namespace video_rental.Controllers
{
    public class RentalController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IRentalRepository rentalRepository;
        private readonly ITransactionRepository transactionRepository;

        public RentalController(IMovieRepository  movieRepository,ICustomerRepository customerRepository,IRentalRepository rentalRepository,ITransactionRepository transactionRepository)
        {
            this.movieRepository = movieRepository;
            this.customerRepository = customerRepository;
            this.rentalRepository = rentalRepository;
            this.transactionRepository = transactionRepository;
        }

        [HttpPost]
        public ActionResult Rent(string[] movieNames, int rentalDuration)
        {
            var customer = GetCustomer(Request.Cookies);
            var movies = movieRepository.WithTitles(movieNames);
            var now = DateTime.Now;
            var rentalPeriod = TimeSpan.FromDays(rentalDuration);
            var rentals = movies.Select(x=> new Rental(customer,x,rentalPeriod,now)).ToList();
            rentalRepository.Add(rentals);
            var transaction = new Transaction(now, customer, new HashSet<Rental>(rentals));
            transactionRepository.Add(transaction);
            var str = customer.Statement(transaction.Rentals);
            return View((object)str);
        }

        private Customer GetCustomer(HttpCookieCollection httpCookieCollection)
        {
            return customerRepository.SelectUnique(x=> x.Name.Equals(httpCookieCollection[LoginFilter.VideoRentalcookie].Value));
        }

        public ActionResult CurrentRentals(){
            return View(rentalRepository.CurrentRentalsFor(GetCustomer(Request.Cookies)));
        }
    
        public ActionResult History(){
            return View(transactionRepository.TransactionsBy(GetCustomer(Request.Cookies)));
        }

    }
}
