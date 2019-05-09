using ItRental.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ItRental.Dal.Services
{
    public class OpeningHoursServices
    {
        private string UrlOpeningHours { get; set; } = "http://api.aspitcloud.dk/openinghours";
        private string UrlIsOpen { get; set; } = "http://api.aspitcloud.dk/isopen";

        public OpeningHoursInfo GetOpeningHours()
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = new WebClient().DownloadString(UrlOpeningHours);
            }
            OpeningHoursInfo openingHoursInfo = JsonConvert.DeserializeObject<OpeningHoursInfo>(json);
            return openingHoursInfo;
        }

        public bool IsOpen()
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = new WebClient().DownloadString(UrlIsOpen);
            }
            bool isOpen = JsonConvert.DeserializeObject<IsOpenNow>(json).IsOpen;
            return isOpen;
        }
    }
}
