using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using projectFlight.Dal;
using projectFlight.Models;
using projectFlight.ViewModel;

namespace projectFlight.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Load()

        {
            Flight myFlight = new Flight
            {
                flightId = "123A",

                flightTo = "Greece",

                flightFrom = "Isreal",
                  price=100,
                  numberOfSeats=200,

                  soldCount=0,

                  timeFlight="21:00",

                  dateFlight= Convert.ToDateTime(01/01/2023),



                   dateBackFlight = Convert.ToDateTime(04 / 01 / 2023)
            };
            return View("Index",myFlight);
        }

        public ActionResult Contact()
        {
            return View();
        }


        public  ActionResult Index()
        {
            
            Dal1 dal = new Dal1();
            List<Flight> testNotNullDb = (from x in dal.Flights select x).ToList<Flight>();

         
            string valFrom = Request.Form["txtFrom"]?.ToString();
            string valTo= Request.Form["txtWhere"]?.ToString();
            string valDate = Request.Form["txtDate"]?.ToString();
            string valDateBack = Request.Form["txtDateBack"]?.ToString();
            string valOneWay = Request.Form["oneWay"]?.ToString();
            //string val = Request.Form["txtWhere"].ToString();
            List<Flight> fli = (from x in dal.Flights where x.flightTo.Contains(valTo)  &&  x.flightFrom.Contains(valFrom)  && x.oneWay.ToString()==valOneWay

                                                                                            select x).ToList<Flight>();
                FlightViewModel cvm = new FlightViewModel();
                cvm.Flights = fli;

                foreach (var f in fli)
                {
                    Console.WriteLine(f.flightId);
                }
                return View(cvm);
            
          
        }

        public ActionResult ShowSearch()
        {
            FlightViewModel cvm = new FlightViewModel();
            cvm.Flights = new List<Flight>();
            return View("Index", cvm);
        }


    }
}