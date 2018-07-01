using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.domain
{
    class CountryDesc
    {
        public string country_code { get; set; }
        public string country_description { get; set; }

        public static CountryDesc FromCsv(string csvLine)
        {
            string[] values = csvLine.Split('|');
            CountryDesc countryDesc = new CountryDesc();
            countryDesc.country_code = values[0].ToString();
            countryDesc.country_description = values[1].ToString();         

            return countryDesc;
        }
    }
}
