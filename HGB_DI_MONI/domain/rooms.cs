using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class Rooms
    {
        public string room_code { get; set; }
        public string room_name { get; set; }
        public List<Rates> room_rates { get; set; }

    }
}
