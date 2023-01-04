using projectFlight.Models;
using projectFlight.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectFlight.Models;
using projectFlight.Dal;
using System.Data.SqlClient;


namespace projectFlight.Controllers
{
    public class OrderController : Controller
    {


       

        [HttpPost]
        public ActionResult Payment(string fid,string fprice,string OrderID, string cardNum,string cardDate,string cvv,string custID,string noTick,string fullName, string totalPrice, string creditCardSave)
        {
            int total=0;
            Dal1 dal = new Dal1();
            Flight flight = dal.Flights.Find(fid);
            int priceForFlight = Convert.ToInt32(fprice);
            total = priceForFlight * Convert.ToInt32(noTick);
            Random rnd = new Random();
            Order order = new Order();
          
                    order. flightId = fid;
                    order.orderId = rnd.Next().ToString();
            if (flight.numberOfSeats >= Convert.ToInt32(noTick))
                order.NoTicket = Convert.ToInt32(noTick);
            else
                ViewBag["error"] = "cannoit book this number os seats";
                    order.TotalPrice = fprice;
                    order.custumerId = custID;
                    order.cardDate = cardDate;
                    order.cardNumber = cardNum;
                    order.cvv = cvv;
                    order.fullName = fullName;
                     //ViewBag.TotalPrice = totalPrice;

                    dal.SaveChanges();
                    return View(order);
        }


     
       






        [HttpPost]
        public ActionResult SummaryOrder([Bind(Include = "orderId,flightId,NoTicket,TotalPrice,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        {
            Dal1 dal = new Dal1();
            List<Order> objOrders = dal.Orders.ToList();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Order = order;
           
            if (ModelState.IsValid)
            {

                dal.Orders.Add(order);
                dal.SaveChanges();
             
            }

            Flight f = dal.Flights.Find(order.flightId);
            f.soldCount = f.soldCount + order.NoTicket;
            f.numberOfSeats =f.numberOfSeats- order.NoTicket;
            dal.SaveChanges();

            return View(order);
        }

        public ActionResult SummaryOrder()
        {
            return View();
        }

        public ActionResult Index()
        {
            
            return RedirectToAction("Home","Index");
        }

       
    }
}