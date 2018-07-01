using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class RoomImage
    {
        public long hotel_code { get; set; }
        public string hotel_name { get; set; }
        public string hotel_countryCode { get; set; }
        public string hotel_destinationCode { get; set; }
        public long imageOrder { get; set; }
        public string imageTypeCode { get; set; }
        public string imageroomCode { get; set; }        
        public string room_typeDescription { get; set; }
        public string imagePath { get; set; }
    }
}
