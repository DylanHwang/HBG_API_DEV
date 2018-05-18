using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class HotelRooms
    {
        public long hotel_code { get; set; }
        public string hotel_name { get; set; }
        public string hotel_destinationCode { get; set; }
        public string hotel_destinationName { get; set; }
        public long hotel_zoneCode { get; set; }
        public string hotel_zoneName { get; set; }
        public string room_code { get; set; }
        public string room_name { get; set; }        
        public string net { get; set; }
        public string sellingRate { get; set; }
        public bool packaging { get; set; }
        public String checkIn { get; set; }
        public String checkOut { get; set; }
        public bool callBack { get; set; }
        public string rateKey { get; set; }
        public string rateType { get; set; }

    }
}
