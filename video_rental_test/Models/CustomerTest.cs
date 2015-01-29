using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using video_rental.Models;

namespace video_rental_test.Models
{
    [TestFixture]
    public class CustomerTest
    {

        private static readonly HashSet<Rental> EMPTY_RENTALS = new HashSet<Rental>();

        private Customer customer;
        private HashSet<Rental> mixedRentals;

        [SetUp]
        public void setUp()
        {
            customer = new Customer("John Smith");

            Movie montyPython = new Movie("Monty Python and the Holy Grail");
            Movie ran = new Movie("Ran");
            Movie laConfidential = new Movie("LA Confidential");
            Movie starTrek = new Movie("Star Trek 13.2");
            Movie WallaceAndGromit = new Movie("Wallace and Gromit");

            mixedRentals = new HashSet<Rental>();
            DateTime rentedOn = new DateTime();
            mixedRentals.Add(new Rental(customer, montyPython, TimeSpan.FromDays(3), rentedOn));
            mixedRentals.Add(new Rental(customer, ran, TimeSpan.FromDays(1), rentedOn));
            mixedRentals.Add(new Rental(customer, laConfidential, TimeSpan.FromDays(2), rentedOn));
            mixedRentals.Add(new Rental(customer, starTrek, TimeSpan.FromDays(1), rentedOn));
            mixedRentals.Add(new Rental(customer, WallaceAndGromit, TimeSpan.FromDays(6), rentedOn));
        }

        [Test]
        public void testEmpty()
        {
            string noRentalsStatement =
                    "Rental Record for John Smith\n"
                            + "Amount charged is $0.0";
            Assert.AreEqual(noRentalsStatement, customer.Statement(EMPTY_RENTALS));
        }

        [Test]
        public void testCustomer()
        {
            string expected =
                    "Rental Record for John Smith\n"
                            + "  Monty Python and the Holy Grail  -  $3.0\n"
                            + "  Ran  -  $1.0\n"
                            + "  LA Confidential  -  $2.0\n"
                            + "  Star Trek 13.2  -  $1.0\n"
                            + "  Wallace and Gromit  -  $6.0\n"
                            + "Amount charged is $13.0";
            Assert.AreEqual(expected, customer.Statement(mixedRentals));
        }

    }
}
