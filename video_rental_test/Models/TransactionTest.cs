using System;
using System.Collections.Generic;
using NUnit.Framework;
using video_rental.Models;

namespace video_rental_test.Models
{
    [TestFixture]
    public class TransactionTest
    {
        private static readonly Movie FINDING_NEMO = new Movie("Finding Nemo");
        private static readonly Movie SHAWSHANK_REDEMPTION = new Movie("Shawshank Redemption");
        private static readonly Customer CUSTOMER_ONE = new Customer("James Cameron");
        private static readonly Customer CUSTOMER_TWO = new Customer("Quentin Tarantino");
        private static readonly Rental RENTAL_ONE = new Rental(CUSTOMER_ONE, FINDING_NEMO, TimeSpan.FromDays(1), new DateTime());
        private static readonly Rental RENTAL_TWO = new Rental(CUSTOMER_ONE, SHAWSHANK_REDEMPTION, TimeSpan.FromDays(3), new DateTime());

        [Test]
        public void ShouldReturnDifferentRentalSetFromConstruction()
        {
            var rentals = new HashSet<Rental> {RENTAL_ONE};
            var transaction = new Transaction(new DateTime(), CUSTOMER_ONE, rentals);

            rentals.Add(RENTAL_TWO);

            Assert.IsFalse(rentals.Equals(transaction.Rentals));
            Assert.That(transaction.Rentals,Is.EquivalentTo(new HashSet<Rental> { RENTAL_ONE }));
        }

        [Test]
        public void ShouldReturnUnmodifiableRentalSet()
        {
            var transaction = new Transaction(new DateTime(), CUSTOMER_ONE, new HashSet<Rental> { RENTAL_ONE });
            transaction.Rentals.Clear();
            Assert.That(transaction.Rentals.Count,Is.EqualTo(1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionIfRentalForDifferentCustomer()
        {
            new Transaction(new DateTime(), CUSTOMER_TWO, new HashSet<Rental> { RENTAL_ONE });
        }
    }
}
