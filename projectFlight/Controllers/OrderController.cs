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
        public ActionResult Payment(string fid,string OrderID, string cardNum,string cardDate,string cvv,string custID,string noTick,string fullName, string totalPrice, string creditCardSave)
        {
            string total;
            Dal1 dal = new Dal1();
            Flight flight = dal.Flights.Find(fid);
            int priceForFlight = flight.price;
            total = ((priceForFlight) * Convert.ToInt32(noTick)).ToString();
            Random rnd = new Random();
             Order order = new Order();
            
                    order. flightId = fid;
                    order.orderId = rnd.Next().ToString();
                    order.NoTicket = Convert.ToInt32(noTick);
                    order.TotalPrice = (flight.price).ToString();
                    order.custumerId = custID;
                    order.cardDate = cardDate;
                    order.cardNumber = cardNum;
                    order.cvv = cvv;
                    order.fullName = fullName;
           
                    
                     return View(order);
        }






        [HttpPost]
        public ActionResult SummaryOrder([Bind(Include = "orderId,flightId,NoTicket,TotalPrice,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        {
            Dal1 dal = new Dal1();
            List<Order> objOrders = dal.Orders.ToList();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Order = order;
            //Flight f = dal.Flights.Find(order.flightId);
            //Order order1 = new Order()
            //{
            //    TotalPrice = (f.price * Convert.ToInt32(order.NoTicket)).ToString()
            // };


            //string total;
          
            //Flight flight = dal.Flights.Find(order.flightId);
            //int priceForFlight = flight.price;
            //total = ((priceForFlight) * Convert.ToInt32(order.NoTicket)).ToString();
            //order.TotalPrice = total;
            if (ModelState.IsValid)
            {

                dal.Orders.Add(order);
                dal.SaveChanges();
                //return RedirectToAction("BookOrder");
            }

            Flight f = dal.Flights.Find(order.flightId);
           f.numberOfSeats =f.numberOfSeats- order.NoTicket;
            //dal.Entry(f).State = System.Data.Entity.EntityState.Modified;
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