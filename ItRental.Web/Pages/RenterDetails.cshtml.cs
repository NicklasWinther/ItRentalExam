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
        private RenterRepository RenterRepository { get; set; } = new RenterRepository();
        private RentalRepository RentalRepository { get; set; } = new RentalRepository();
        private EquipmentRepository EquipmentRepository { get; set; } = new EquipmentRepository();
        [BindProperty]
        public Renter Renter { get; set; }
        [BindProperty]
        public List<Equipment> Equipments { get; set; } 
        [BindProperty]
        public Rental Rental { get; set; }

        public void OnGet(int id)
        {
            Renter = RenterRepository.GetRenter(id);
            Renter.Rentals = RentalRepository.GetRentalsFor(Renter.Id);
            Equipments = EquipmentRepository.GetEquipments();

        }
        public IActionResult OnPost()
        {
            Rental.Renter = Renter;
            RentalRepository.CreateRental(Rental);
            return Redirect($"~/RenterDetails/{Renter.Id}");
        }
    }
}