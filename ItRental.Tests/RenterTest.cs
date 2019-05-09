using ItRental.Entities;
using System;
using Xunit;

namespace ItRental.Tests
{
    public class RenterTest
    {
        [Fact]
        public void GotOverdueRental_ReturnsFalseWithNoRentals()
        {
            //Arrange
            Renter renter = new Renter();

            //Act
            bool gotOverdueRental = renter.GotOverdueRental();

            //Assert
            Assert.False(gotOverdueRental);
        }

        [Fact]
        public void GotOverdueRental_ReturnsFalseWithRentals()
        {
            //Arrange
            Renter renter = new Renter();
            
            Rental rental = new Rental()
            {
                ReturnTime = DateTime.Today.AddDays(10)
            };
            Rental rental2 = new Rental()
            {
                ReturnTime = DateTime.Today
            };

            renter.Rentals.Add(rental);
            renter.Rentals.Add(rental2);

            //Act
            bool gotOverdueRental = renter.GotOverdueRental();

            //Assert
            Assert.False(gotOverdueRental);
        }

        [Fact]
        public void GotOverdueRental_ReturnsTrueWithOverdueRentals()
        {
            //Arrange
            Renter renter = new Renter();

            Rental rental = new Rental()
            {
                ReturnTime = DateTime.Today.AddDays(-10)
            };
            Rental rental2 = new Rental()
            {
                ReturnTime = DateTime.Today
            };

            renter.Rentals.Add(rental);
            renter.Rentals.Add(rental2);

            //Act
            bool gotOverdueRental = renter.GotOverdueRental();

            //Assert
            Assert.True(gotOverdueRental);
        }
    }
}
