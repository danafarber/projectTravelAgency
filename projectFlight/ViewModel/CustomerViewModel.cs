using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectFlight.Models;
namespace projectFlight.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }

        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
    }

}