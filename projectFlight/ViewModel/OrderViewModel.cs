using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectFlight.Models;

namespace projectFlight.ViewModel
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }

        public Flight Flight { get; set; }
        public List<Flight> Flights { get; set; }

        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }

    }
}