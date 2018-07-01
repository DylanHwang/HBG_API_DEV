using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class DestinationDesc
    {
        public string destinatin_code { get; set; }
        public string destinatin_name { get; set; }
        public string destinatin_countryCode { get; set; }
        public string destinatin_zonecode { get; set; }
        public string destinatin_zonecode_name { get; set; }

        public static DestinationDesc FromCsv(string csvLine)
        {
            string[] values = csvLine.Split('|');
            DestinationDesc destinationDesc = new DestinationDesc();
            destinationDesc.destinatin_code = values[0].ToString();
            destinationDesc.destinatin_name = values[1].ToString();
            destinationDesc.destinatin_countryCode = values[2].ToString();
            destinationDesc.destinatin_zonecode = values[3].ToString();
            destinationDesc.destinatin_zonecode_name = values[4].ToString();

            return destinationDesc;
        }
    }
}

