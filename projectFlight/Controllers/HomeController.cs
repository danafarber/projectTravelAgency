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



        //public ActionResult Index()
        //{

        //    Dal1 dal = new Dal1();
        //    List<Flight> testNotNullDb = (from x in dal.Flights select x).ToList<Flight>();


        //    string valFrom = Request.Form["txtFrom"]?.ToString();
        //    string valTo = Request.Form["txtWhere"]?.ToString();
        //    string valDate = Request.Form["txtDate"]?.ToString();
        //    string valDateBack = Request.Form["txtDateBack"]?.ToString();
        //    bool valOneWay = Convert.ToBoolean(Request.Form["oneWay"]?.ToString());


        //    //string val = Request.Form["txtWhere"].ToString();

        //    //Flight found = dal.Flights.Find(valFrom, valTo,valDate,valDateBack,valOneWay);

        //    List<Flight> fli = (from x in dal.Flights
        //                        where (x.dateFlight.ToString() == valDate
        //                               && x.flightTo == valTo
        //                               && x.oneWay == valOneWay)
        //                        select x).ToList<Flight>();






        //    FlightViewModel cvm = new FlightViewModel();
        //    cvm.Flights = fli;
        //    foreach (Flight f in fli)
        //    {
        //        ViewData["flightIdValue"] = f.flightId.ToString();
        //        Session["flightIdValue"] = f.flightId;
        //        Session["priceValue"] = f.price;

        //    }

        //    return View(cvm);

        //    //x.flightTo==valTo &&
        //}/
        //[HttpPost]
        public ActionResult Index()
        {

            Dal1 dal = new Dal1();
            //List<Flight> testNotNullDb = (from x in dal.Flights select x).ToList<Flight>();


            string valFrom = Request.Form["txtFrom"]?.ToString();
            string valTo = Request.Form["txtWhere"]?.ToString();
            string valDate = Request.Form["txtDate"]?.ToString();
            string valDateBack = Request.Form["txtDateBack"]?.ToString();
            string valOneWay1 = Request.Form["oneWay"]?.ToString();
            bool valOneWay = Convert.ToBoolean(valOneWay1);
            //bool valOneWay=true;
            // bool temp = flight.Flight.oneWay;

            var fli = (from x in dal.Flights select x);


            if (string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                && string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                && string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                 && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
                  
            {
                fli = fli;
            }

            else if(!string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                 && !string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
            {
                fli = fli.Where(x =>
                              (x.dateFlight.ToString() == valDate
                              && x.flightTo == valTo
                              && x.flightFrom == valFrom
                              && x.dateBackFlight.HasValue)
                              ||
                             (x.dateBackFlight.ToString() == valDateBack
                              && x.flightTo == valTo
                              && x.flightFrom == valFrom
                             ));
            
             }
           
            else if (!string.IsNullOrWhiteSpace(Request.Form["txtFrom"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtWhere"])
                && !string.IsNullOrWhiteSpace(Request.Form["txtDate"])
                 && string.IsNullOrWhiteSpace(Request.Form["txtDateBack"]))
            {
                fli = fli.Where(x =>
                               x.dateFlight.ToString() == valDate
                              && x.flightTo == valTo
                              && x.flightFrom == valFrom
                              && x.dateBackFlight==null
                              );

            }
            //if (valOneWay == true)
            //{


            //if (valTo != null && valFrom != null && valDate != null && valDateBack == null)
            //{
            //    //List<Flight> tempfl= (from x in dal.Flights
            //    //                     where x.dateBackFlight==null
            //    //                     select x).ToList<Flight>();
            //    //fli = (from x in dal.Flights
            //    //       where (!x.dateBackFlight.HasValue
            //    //              && x.dateFlight.ToString() == valDate
            //    //              && x.flightTo == valTo
            //    //              && x.flightFrom == valFrom)
            //    //       select x).ToList<Flight>();
            //    fli = fli.Where(x => x.dateFlight.ToString() == valDate
            //                       && x.flightTo == valTo
            //                       && x.flightFrom == valFrom
            //                       && !x.dateBackFlight.HasValue);

            //}

            ////}
            ////else if(valOneWay == false)
            ////{
            //else if (valTo != null && valFrom != null && valDate != null && valDateBack != null)
            //{
            //    fli = fli.Where(x => x.dateFlight.ToString() == valDate
            //                  && x.flightTo == valTo
            //                  && x.flightFrom == valFrom
            //                  && x.dateBackFlight.HasValue
            //                  && x.dateBackFlight.ToString() == valDateBack);
            //}


            //}
            //two ways
            //fli = (from x in dal.Flights
            //       where (x.dateBackFlight.HasValue

            //              )
            //       select x).ToList<Flight>();

            //fli = (from x in dal.Flights
            //       where (x.dateBackFlight.HasValue
            //              && x.dateFlight.ToString() == valDate
            //              && x.flightTo == valTo
            //              && x.oneWay == valOneWay
            //              && x.flightFrom == valFrom)
            //       select x).ToList<Flight>();

            //else if(valOneWay==false) //two ways-->date back !=null
            //{
            //    if(valDateBack!=null )
            //    {
            //        fli = (from x in dal.Flights
            //               where (x.flightFrom == valFrom
            //               && x.flightTo == valTo
            //               && x.dateFlight.ToString() == valDate)
            //               ||
            //               (x.dateBackFlight.ToString() == valDateBack
            //               && x.flightTo == valTo
            //               && x.flightFrom == valFrom)select x).ToList<Flight>();

            //    }
            //}
            //else
            //{
            //    ViewBag.Message = "Please fill all the required fiileds";
            //}
            //List<Flight> fli = (from x in dal.Flights
            //                    where ( x.dateFlight.ToString()==valDate
            //                           && x.flightTo == valTo 
            //                           && x.oneWay==valOneWay)
            //                    select x).ToList<Flight>();






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
        //[Bind(Include ="orderId,flightId,noTicket,TotalPrice,seatNumber,custumerId,cardNumber,cardDate,cvv")] Order order
        //public ActionResult BookOrder()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult BookOrder()
        //{
           
        //    Dal1 dal = new Dal1();
        //    string ordid = Request.Form["Order.flightId"]?.ToString();
        //    //string url = Request.RawUrl;
        //    //string query = Request.Url.Query;
        //    //string isAllowed = Request.QueryString["id"];
        //    //string flightId = order.flightId;
        //    int niT =Convert.ToInt32( Request.Form["Order.NoTicket"]?.ToString());
        //   // string seat = Request.Form["Order.flightId"]?.ToString();
        //    string cid = Request.Form["Order.custumerId"]?.ToString();
        //    string card = Request.Form["Order.cardNumber"]?.ToString();
        //    string date = Request.Form["Order.cardDate"]?.ToString();
        //    string cvv = Request.Form["Order.cvv"]?.ToString();


        //    List<Order> objOrders = dal.Orders.ToList<Order>();
        //    OrderViewModel orderModel = new OrderViewModel();
        //    Order order = new Order();
          

        //    if (ModelState.IsValid)
        //    {
        //        dal.Orders.Add(order);
        //        dal.SaveChanges();
        //        return View("Index");

        //    }

        //    return View(order);
            
            
           
                

        //    //Dal1 dal = new Dal1();
        //    //List<Customer> objCustomers = dal.Customers.ToList<Customer>();
        //    //List<Order> objOrders = dal.Orders.ToList<Order>();
        //    //CustomerViewModel cvm = new CustomerViewModel();
        //    //OrderViewModel orderModel = new OrderViewModel();
        //    //orderModel.Order = new Order();
        //    //orderModel.Orders = objOrders;
        //    //cvm.Customer = new Customer();
        //    //cvm.Customers = objCustomers;




        //    //if (ModelState.IsValid)
        //    //{
        //    //    Session["SelectedValue"] = orderModel;

        //    //}


        //    //orderModel.Order.flightId = Session["flightIdValue"]?.ToString();
        //    //int totPrice = Convert.ToInt32(Session["flightPriceValue"]?.ToString());
        //    //orderModel.Order.TotalPrice = totPrice.ToString();


        //    //return View(orderModel);
        //}

        //public ActionResult Book(string id)
        //{
        //    Dal1 dal = new Dal1();
        //    Flight f = dal.Flights.Find(id);
        //    return View(f);
        //}
        //[HttpPost, ActionName("Book")]
        //public ActionResult Book([Bind(Include = "id")] Order order)
        //{
        //    Dal1 dal = new Dal1();

        //    string id = order.flightId;
        //    List<Flight> objFlights = dal.Flights.ToList<Flight>();


        //    foreach(Flight f in objFlights)
        //    {
        //        if(id==f.flightId.ToString())
        //        {
        //            Console.WriteLine(id);
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(order);
        //}


        //public ActionResult BookOrder(string id)
        //{
        //    Dal1 dal = new Dal1();
        //    Flight flight = dal.Flights.Find(id);
        //    return View(flight);

        //}



    }
}