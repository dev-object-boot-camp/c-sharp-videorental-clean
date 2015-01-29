using System;
using System.Collections.Generic;
namespace video_rental.Models.Repositories{

    public interface IMovieRepository
    {
        void Add(Movie entity);

        void Add(IEnumerable<Movie> entities);

        HashSet<Movie> SelectAll();

        HashSet<Movie> SelectAll(IComparer<Movie> comparator);

        HashSet<Movie> SelectSatisfying(Func<Movie, bool> specification);

        HashSet<Movie> SelectSatisfying(Func<Movie, bool> specification, IComparer<Movie> comparator);

        Movie SelectUnique(Func<Movie, bool> predicate);

        HashSet<Movie> WithTitles(params String[] titles);
    }
}