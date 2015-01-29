using System;
using System.Collections.Generic;
namespace video_rental.Models.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction entity);

        void Add(IEnumerable<Transaction> entities);

        HashSet<Transaction> SelectAll();

        HashSet<Transaction> SelectAll(IComparer<Transaction> comparator);

        HashSet<Transaction> SelectSatisfying(Func<Transaction, bool> specification);

        HashSet<Transaction> SelectSatisfying(Func<Transaction, bool> specification, IComparer<Transaction> comparator);

        Transaction SelectUnique(Func<Transaction, bool> specification);

        IEnumerable<Transaction> TransactionsBy(Customer customer);
    }

}