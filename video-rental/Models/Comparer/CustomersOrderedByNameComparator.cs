using System.Collections.Generic;
using video_rental.Models;
namespace video_rental.Models.Comparer{
public class CustomersOrderedByNameComparator : IComparer<Customer> {

    public int Compare(Customer customer1, Customer customer2) {
        return (customer1 == customer2) ? 0 : customer1.Name.CompareTo(customer2.Name);
    }

}
}
