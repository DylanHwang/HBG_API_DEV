using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class Hotels
    {
        public long hotel_code { get; set; }
        public string hotel_name { get; set; }
        public string hotel_destinationCode { get; set; }
        public string hotel_stringdestinationName { get; set; }
        public long hotel_zoneCode { get; set; }
        public string hotel_zoneName { get; set; }
        public List<Rooms> hotel_rooms { get; set; }
    }
}
