using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class HotelRoomTypeInfo
    {
        public long hotel_code { get; set; }
        public string hotel_name { get; set; }
        public string hotel_countryCode { get; set; }
        public string hotel_countryName { get; set; }
        public string hotel_destinationCode { get; set; }
        public string hotel_destinationName { get; set; }
        public string roomCode { get; set; }
        public string roomCodeDescription { get; set; }
        public string roomType { get; set; }
        public string characteristicCode { get; set; }    
        
    }
}
