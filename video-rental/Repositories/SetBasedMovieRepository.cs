using System.Collections.Generic;
using video_rental.Models;
using video_rental.Models.Repositories;
using System.Linq;
namespace video_rental.Repositories{
public class SetBasedMovieRepository : SetBasedRepository<Movie> , IMovieRepository {

    public SetBasedMovieRepository(IEnumerable<Movie> entities) : base(entities) {
    }

    public HashSet<Movie> WithTitles(params string[] titles) {
        return SelectSatisfying(x => titles.ToList().Contains(x.Title));
    }
}
}
