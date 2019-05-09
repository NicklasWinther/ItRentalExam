using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal.Services;
using ItRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class IndexModel : PageModel
    {
        public OpeningHoursInfo OpeningHoursInfo { get; set; }
        public OpeningHoursServices OpeningHoursServices { get; set; } = new OpeningHoursServices();
        public string IsOpen { get; set; } = "";
        public void OnGet()
        {
            OpeningHoursInfo = OpeningHoursServices.GetOpeningHours();
            foreach (OpeningHours openingHours in OpeningHoursInfo.OpeningHours)
            {
                if (openingHours.OpeningHour == null)
                {
                    openingHours.OpeningHour = "Lukket";
                }
                if (openingHours.ClosingHour == null)
                {
                    openingHours.ClosingHour = "Lukket";
                }
            }

            if (OpeningHoursServices.IsOpen())
            {
                IsOpen = "Åbent";
            }
            else
            {
                IsOpen = "Lukket";
            }
        }
    }
}