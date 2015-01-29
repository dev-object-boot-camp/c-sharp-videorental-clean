using System.Collections.Generic;
using video_rental.Models;
using video_rental.Models.Repositories;

namespace video_rental.Repositories
{
    public class SetBasedCustomerRepository : SetBasedRepository<Customer>, ICustomerRepository
    {
        public SetBasedCustomerRepository(IEnumerable<Customer> customers) : base(customers)
        {
        }
    }
}