using System.Web.Mvc;
using video_rental.Models.Repositories;

namespace video_rental.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public HomeController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public ActionResult Index()
        {
            return View(movieRepository.SelectAll());
        }
        
        
    }
}
