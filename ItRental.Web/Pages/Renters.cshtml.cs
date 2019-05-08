using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class RentersModel : PageModel
    {
        public List<Renter> Renters { get; set; }
        [BindProperty]
        public Renter NewRenter { get; set; }
        [Display(Name = "Navn")]
        [BindProperty]
        public string NameSearch { get; set; } = "";
        public string MessageSearch { get; set; }
        public string MessageAdd { get; set; } = "";
        public List<Rental> Rentals { get; set; }

        public RentersModel()
        {
            RenterRepository renterRepository = new RenterRepository();
            RentalRepository rentalRepository = new RentalRepository();
            Renters = renterRepository.GetRenters();
            Rentals = rentalRepository.GetAllRentals();
        }
        public void OnGet()
        {
         
        }
        public void OnPostAdd()
        {
            if (string.IsNullOrWhiteSpace(NewRenter.Name))
            {
                MessageAdd = "Navn skal udfyldes";
            }
            else
            {
                MessageAdd = "Låner oprettet";
                RenterRepository renterRepository = new RenterRepository();
                renterRepository.AddRenter(NewRenter);
            }
        }
        public void OnPostSearch()
        {
            if (string.IsNullOrWhiteSpace(NameSearch))
            {
                MessageSearch = "Skriv noget";
            }
            else
            {
                RenterRepository renterRepository = new RenterRepository();
                Renters = renterRepository.SearchRenters(NameSearch);
            }
        }
    }
}