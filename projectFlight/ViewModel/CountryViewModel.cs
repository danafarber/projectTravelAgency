using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectFlight.Models;
namespace projectFlight.ViewModel
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public List<Country> Countries { get; set; }
    }
}