using System;
using System.Collections.Generic;
namespace video_rental.Models.Repositories{

    public interface ICustomerRepository
    {
        void Add(Customer entity);

        void Add(IEnumerable<Customer> entities);

        HashSet<Customer> SelectAll();

        HashSet<Customer> SelectAll(IComparer<Customer> comparer);

        Customer SelectUnique(Func<Customer, bool> predicate);

        HashSet<Customer> SelectSatisfying(Func<Customer, bool> specification);

        HashSet<Customer> SelectSatisfying(Func<Customer, bool> specification, IComparer<Customer> comparator);
    }
}