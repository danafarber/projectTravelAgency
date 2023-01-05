using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
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

        //https://localhost:44385/


        public ActionResult Index(string radioButton)
        {

            Dal1 dal = new Dal1();
       


            string valFrom = Request.Form["txtFrom"]?.ToString();
            string valTo = Request.Form["txtWhere"]?.ToString();
            string valDate = Request.Form["txtDate"]?.ToString();
            string valDateBack = Request.Form["txtDateBack"]?.ToString();
            string valOneWay1 = Request.Form["oneWay"]?.ToString();
            bool valOneWay = Convert.ToBoolean(valOneWay1);
            
            
          
            var fli = (from x in dal.Flights select x);


            if (string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                && string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                && string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                 && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
                  
            {
                fli = fli;
            }


           if (string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
               && string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
               && string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"])
                && radioButton == "Two Ways")

            {
                fli = fli.Where(x => x.oneWay == false);
            }


             if (string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
              && string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
              && string.IsNullOrWhiteSpace(Request.Form["txtDate"])
               && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"])
               && radioButton == "One Way")

            {
                fli = fli.Where(x => x.oneWay == true);
            }



            if (radioButton == "Two Ways")
            {
                if (!string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                   && !string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                   && !string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                    && !string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
                {

                    DateTime valDateParsed = DateTime.Parse(valDate);
                    DateTime valDateBackParsed = DateTime.Parse(valDateBack);
                    Console.WriteLine(valDateParsed.ToString());

                    fli = fli.Where(x =>

                                  
                                    x.dateBackFlight != null
                                    && x.oneWay == false
                                    && x.flightTo == valTo
                                    && x.flightFrom == valFrom
                            
                                 );
                 
                }
            }

                 
            if (radioButton == "One Way")
            {
                if (!string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                 && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
                {
                    fli = fli.Where(x =>
                                         x.dateFlight.ToString() == valDate
                                      && x.flightTo == valTo
                                      && x.flightFrom == valFrom
                                      && x.dateBackFlight.Value == null
                                      && x.oneWay == true
                                  );

                }

            }

          




            FlightViewModel cvm = new FlightViewModel();
            cvm.Flights = fli.ToList<Flight>();


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