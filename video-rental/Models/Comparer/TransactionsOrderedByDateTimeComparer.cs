using System.Collections.Generic;
namespace video_rental.Models.Comparer{

    public class TransactionsOrderedByDateTimeComparer : IComparer<Transaction>
    {
        public int Compare(Transaction transaction1, Transaction transaction2)
        {
            return transaction1.DateTime.CompareTo(transaction2.DateTime);
        }

    }
}
