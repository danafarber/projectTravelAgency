using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectFlight.Dal;
using projectFlight.Models;
using projectFlight.ViewModel;

namespace projectFlight.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dal1 dal = new Dal1();
            string val = Request.Form["txttxtWhere"].ToString();
            List<Flight> fli = (from x in dal.Flights where x.flightFrom.Contains(val) select x).ToList<Flight>();
            FlightViewModel cvm = new FlightViewModel();
            cvm.Flights = fli;
            return View(cvm);
           
        }

     
    }
}