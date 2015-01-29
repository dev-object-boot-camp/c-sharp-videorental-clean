using System;
using System.Collections.Generic;
using video_rental.Models;
using video_rental.Models.Repositories;

namespace video_rental.Repositories
{
    public class SetBasedRentalRepository : SetBasedRepository<Rental>, IRentalRepository
    {
        public HashSet<Rental> CurrentRentalsFor(Customer customer)
        {
            return SelectSatisfying(x => customer.Equals(x.Customer) && !(x.EndDate < DateTime.Now));
        }
    }
}