using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace video_rental.Models
{
    public class Movie
    {
        public Movie(string title)
        {
            this.Title = title;
        }

        public string Title { get; private set; }

        public double GetCharge(int daysRented)
        {
            return daysRented * 1;
        }
    }
}