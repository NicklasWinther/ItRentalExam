using System;
using System.Collections.Generic;
using System.Text;

namespace ItRental.Entities
{
    public class Rental : IComparable
    {
        public int Id { get; set; }
        public DateTime RentalTime { get; set; }
        public DateTime ReturnRime { get; set; }
        public Equipment Equipment { get; set; }
        public int Units { get; set; }
        public Renter Renter { get; set; }

        public bool IsRentalOverdue()
        {
            if (ReturnRime < DateTime.Now)
            {
                return true;
            }
            return false;
        }
        public int CompareTo(object obj)
        {
            return ReturnRime.CompareTo(obj);
        }
    }
}
