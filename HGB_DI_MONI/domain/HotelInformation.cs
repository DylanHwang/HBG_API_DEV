using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class HotelInformation
    {
        public long code { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public string destinationCode { get; set; }        
        public string zoneCode { get; set; }        
        public string longitude { get; set; }
        public string latitude { get; set; }        
        public string chainCode { get; set; }
        public string accommodationTypeCode { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }        
        public string phoneNumber { get; set; }
        public string S2C { get; set; }
    }
}
