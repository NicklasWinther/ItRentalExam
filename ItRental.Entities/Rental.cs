using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItRental.Entities
{
    public class Rental : IComparable<Rental>
    {
        public int Id { get; set; }
        public DateTime RentalTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public Equipment Equipment { get; set; }
        public int Units { get; set; }
        public Renter Renter { get; set; }

        public bool IsRentalOverdue()
        {
            if (ReturnTime == DateTime.Today)
            {
                return false;
            }
            else if (ReturnTime < DateTime.Today)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Rental other)
        {
            return ReturnTime.CompareTo(other.ReturnTime);
        }
    }
}
