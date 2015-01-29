using System.Collections.Generic;
using video_rental.Models;
using video_rental.Models.Comparer;
using video_rental.Models.Repositories;
namespace video_rental.Repositories{

    public class SetBasedTransactionRepository : SetBasedRepository<Transaction>, ITransactionRepository
    {
        public SetBasedTransactionRepository()
            : base()
        {
        }

        public IEnumerable<Transaction> TransactionsBy(Customer customer)
        {
            return SelectSatisfying(x => x.Customer.Equals(customer), new TransactionsOrderedByDateTimeComparer());
        }
    }
}
