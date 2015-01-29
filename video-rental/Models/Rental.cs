using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace video_rental.Models
{
    public class Rental
    {
        public Rental(Customer customer, Movie movie, TimeSpan period, DateTime rentedOn)
        {
            this.Movie = movie;
            this.Customer = customer;
            this.Period = period;
            this.RentedOn = rentedOn;
        }

        public Movie Movie { get; private set; }

        public Customer Customer { get; private set; }

        public TimeSpan Period { get; private set; }

        public DateTime RentedOn { get; private set; }

        public DateTime EndDate { get { return RentedOn.Add(Period); } }
    }
}