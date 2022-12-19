using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectFlight.Models;

namespace projectFlight.ViewModel
{
    public class FlightViewModel
    {

        public Flight Flight { get; set; }
        public List<Flight> Flights { get; set; }
       
    }
}