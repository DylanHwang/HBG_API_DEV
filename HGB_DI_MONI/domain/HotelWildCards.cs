using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class HotelWildCards
    {
        public long hotel_code { get; set; }
        public string hotel_name { get; set; }
        public string hotel_countryCode { get; set; }
        public string hotel_countryName { get; set; }
        public string hotel_destinationCode { get; set; }
        public string hotel_destinationName { get; set; }
        public string wildcard_roomType { get; set; }
        public string wildcard_roomTypeDescription { get; set; }
        public string wildcard_roomCode { get; set; }
        public string wildcard_characteristicCode { get; set; }
        public string wildcard_hotelRoomDescription { get; set; }        
    }
}
