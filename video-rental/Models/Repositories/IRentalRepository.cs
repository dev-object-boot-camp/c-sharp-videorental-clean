
using System;
using System.Collections.Generic;
namespace video_rental.Models.Repositories{

    public interface IRentalRepository
    {
        void Add(Rental entity);

        void Add(IEnumerable<Rental> entities);

        HashSet<Rental> SelectAll();

        HashSet<Rental> SelectAll(IComparer<Rental> comparator);

        HashSet<Rental> SelectSatisfying(Func<Rental, bool> specification);

        HashSet<Rental> SelectSatisfying(Func<Rental, bool> specification, IComparer<Rental> comparator);

        Rental SelectUnique(Func<Rental, bool> specification);

        HashSet<Rental> CurrentRentalsFor(Customer customer);
    }
}