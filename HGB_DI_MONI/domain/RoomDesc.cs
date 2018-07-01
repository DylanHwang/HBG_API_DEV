using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class RoomDesc
    {
        public string room_code { get; set; }
        public string room_description { get; set; }
        public string room_type { get; set; }
        public string room_typeDescription { get; set; }
        public string room_characteristic { get; set; }
        public string room_characteristicDescription { get; set; }


        public static RoomDesc FromCsv(string csvLine)
        {
            string[] values = csvLine.Split('|');
            RoomDesc hotelRoom = new RoomDesc();
            hotelRoom.room_code = values[0].ToString();
            hotelRoom.room_description = values[1].ToString();
            hotelRoom.room_type = values[2].ToString();
            hotelRoom.room_typeDescription = values[3].ToString();
            hotelRoom.room_characteristic = values[4].ToString();
            hotelRoom.room_characteristicDescription = values[5].ToString();
          
            return hotelRoom;
        }
    }
}

