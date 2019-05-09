using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItRental.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [Display(Name = "Låner rettigheder")]
        public RenterLevel RenterLevel { get; set; }
        public List<Rental> Rentals { get; set; } = new List<Rental>();
        public int NumberOfRentals { get; }
        public Rental NextRentalDue()
        {
            throw new NotImplementedException();
        }
        public bool GotOverdueRental()
        {
            foreach (Rental rental in Rentals)
            {
                if (rental.IsRentalOverdue())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
