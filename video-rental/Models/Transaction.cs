using System;
using System.Collections.Generic;
using System.Linq;

namespace video_rental.Models
{

    public class Transaction
    {
        private readonly HashSet<Rental> rentals;

        public Transaction(DateTime dateTime, Customer customer, HashSet<Rental> rentals)
        {
            DateTime = dateTime;
            if (rentals.Any(x => !x.Customer.Equals(customer)))
            {
                throw new ArgumentException("Rentals must be for the same customer");
            }
            Customer = customer;
            this.rentals = new HashSet<Rental>(rentals);
        }

        public DateTime DateTime { get; private set; }

        public Customer Customer { get; private set; }

        public HashSet<Rental> Rentals
        {
            get { return new HashSet<Rental>(rentals); }
        }
    }
}