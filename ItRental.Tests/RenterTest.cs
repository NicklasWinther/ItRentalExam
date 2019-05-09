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


            //Act
            renter.Rentals.Add(rental);
            renter.Rentals.Add(rental2);
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


            //Act
            renter.Rentals.Add(rental);
            renter.Rentals.Add(rental2);
            bool gotOverdueRental = renter.GotOverdueRental();

            //Assert
            Assert.True(gotOverdueRental);
        }


        [Fact]
        public void NextRentalDue_ReturnsNullWithNoRentals()
        {
            //Arrange
            Renter renter = new Renter();

            //Act

            //Assert
            Assert.Null(renter.NextRentalDue());
        }

        [Fact]
        public void NextRentalDue_ReturnsCorrectRental()
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


            //Act
            renter.Rentals.Add(rental);
            renter.Rentals.Add(rental2);

            //Assert
            Assert.Equal(rental2, renter.NextRentalDue());
        }
    }
}
