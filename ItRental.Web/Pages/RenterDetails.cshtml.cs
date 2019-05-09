using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class RenterDetailsModel : PageModel
    {
        public Renter Renter { get; set; }
        RenterRepository RenterRepository { get; set; } = new RenterRepository();
        public RentalRepository RentalRepository { get; set; } = new RentalRepository();
        public void OnGet(int id)
        {
            Renter = RenterRepository.GetRenter(id);
            Renter.Rentals = RentalRepository.GetRentalsFor(Renter.Id);
        }
    }
}