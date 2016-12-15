using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF.Test.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
    public class City
    {
        public int CityId { get; set; }
        public String CityName { get; set; }
        public int StateId { get; set; }
    }
}
