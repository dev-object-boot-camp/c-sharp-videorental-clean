using System.Collections.Generic;

namespace video_rental.Models
{
    public class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Statement(IEnumerable<Rental> newRentals)
        {
            var result = "Rental Record for " + Name + "\n";
            double totalAmount = 0;
            foreach (Rental rental in newRentals)
            {
                // show figures for this rental
                var rentalDays = rental.Period.Days;
                result += "  " + rental.Movie.Title + "  -  $" + rental.Movie.GetCharge(rentalDays).ToString("0.0") + "\n";
                totalAmount += rental.Movie.GetCharge(rentalDays);
            }

            // add footer lines
            result += "Amount charged is $" + totalAmount.ToString("0.0");
            return result;
        }

        protected bool Equals(Customer other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}