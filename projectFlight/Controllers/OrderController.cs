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


        // GET: Order
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Load()

        //{
        //    Order myOrder = new Order
        //    {
        //        flightId = Session["flightIdValue"]?.ToString(),
        //        orderId = "1"
        //        ,
        //        NoTicket = 1,
        //        TotalPrice = Session["flightPriceValue"]?.ToString(),
        //        seatNumber = "1a",
        //        custumerId = Session["CustIdVal"]?.ToString(),
        //        cardDate = "09/29",
        //        cvv="123"


        //    };
        //    return View("BookOrder", myOrder);
        //}
        //[HttpPost]

        //public ActionResult BookOrder(string fid)
        //{
        //    Order model = new Order()
        //    {
        //        flightId = fid
        //    };

        //    return View(model);
        //}


        //string ffrom,string fto,int fprice,DateTime fdateFlight, DateTime fdatebackflight
        //[HttpPost]
        //public ActionResult BookOrder(string fid, int? numTic, int? total, string seat, string custId, string card, string dateCard, string cvv, string fullName)
        //{
        //    Random rnd = new Random();

        //    Order Order = new Order()
        //    {
        //        flightId = fid,
        //        orderId = (rnd.Next()).ToString(),
        //        NoTicket = (int)numTic,
        //        TotalPrice = "200".ToString(),
        //        seatNumber = seat,
        //        custumerId = custId,
        //        cardNumber = card,
        //        cardDate = dateCard,
        //        cvv = cvv,
        //        fullName = fullName




        //    };
        //    return View(Order);

        //}

        //public ActionResult Payment(string fid)
        //{
        //    Order o = new Order();
        //    o.flightId=fid;
        //    return View(o);
        //}


        //    [HttpPost]

        //public ActionResult Payment(Order model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        Order reservation = new Order
        //        {
        //            flightId = model.flightId,
        //          fullName = model.fullName,
        //            cardNumber = model.cardNumber,
        //            cardDate=model.cardDate,
        //            TotalPrice = model.TotalPrice,
        //            seatNumber=model.seatNumber,
        //            custumerId=model.custumerId,
        //            cvv=model.cvv,
        //            orderId="12",
        //            NoTicket=model.NoTicket


        //        };
        //        Dal1 dal = new Dal1();
        //        dal.Order.Add(reservation);
        //        dal.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}
        //public ActionResult Payment(string fid,Order order)
        //{
        //    Order model = new Order()
        //    {
        //        flightId = fid
        //    };
        //    Dal1 dal = new Dal1();


        //    if (ModelState.IsValid)
        //    {

        //        dal.Order.Add(order);
        //        dal.SaveChanges();
        //        return RedirectToAction("SummaryOrder");
        //    }

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Payment([Bind(Include = "orderId,flightId,NoTickets,TotalPrice,seatNumber,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        //{
        //    Dal1 dal = new Dal1();


        //    if (ModelState.IsValid)
        //    {

        //        dal.Order.Add(order);
        //        dal.SaveChanges();
        //        return RedirectToAction("SummaryOrder");
        //    }

        //    Flight f = dal.Flights.Find(order.flightId);
        //    // f.numberOfSeats -= order.NoTicket;
        //    //dal.Entry(f).State = System.Data.Entity.EntityState.Modified;
        //    //dal.SaveChanges();

        //    return View(order);
        //}

        //public ActionResult Payment()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public ActionResult Payment(string fid,int tickets,Order order)
        //{
        //    ViewData["Tickets"] = tickets;
        //    Flight f = GetFlight(fid);
        //    Customer c = GetCustomer(order.custumerId);



        //    //Random rnd = new Random();
        //    //order.flightId = f.flightId;
        //    //order.orderId = (rnd.Next()).ToString();
        //    //order.NoTicket = tickets;
        //    //order.TotalPrice = "200".ToString();
        //    //order.seatNumber = "1a";
        //    //order.custumerId =c.custId;
        //    //order.cardNumber = ;
        //    //order.cardDate = model.Order.cardDate;
        //    //order.cvv = model.Order.cvv;
        //    //order.fullName = model.Order.fullName;
        //    //Random rnd = new Random();
        //    //if (ModelState.IsValid)
        //    //{


        //    //    order.flightId = fid;
        //    //    order.orderId = (rnd.Next()).ToString();
        //    //        order.NoTicket = 1;
        //    //        order.TotalPrice = "200".ToString();
        //    //       order.seatNumber = seatNumber;
        //    //       order.custumerId = model.Customer.custId;
        //    //       order.cardNumber = model.Order.cardNumber;
        //    //        order.cardDate = model.Order.cardDate;
        //    //       order.cvv = model.Order.cvv;
        //    //    order.fullName = model.Order.fullName;


        //    //    Dal1 dal = new Dal1();
        //    //    dal.Orders.Add(order);
        //    //    dal.SaveChanges();
        //    //    return RedirectToAction("SummaryOrder");
        //    //}
        //    //return View(model);

        //}



        //[HttpPost]
        //public ActionResult BookOrder( Order order)
        //{
        //    Flight f = new Flight();
        //    Customer c = new Customer();


        //    order.flightId = f.flightId;
        //    order.custumerId = c.custId;

        //    if (ModelState.IsValid)
        //    {
        //        Dal1 dal = new Dal1();
        //        dal.Orders.Add(order);
        //        dal.SaveChanges();
        //        return RedirectToAction("SummaryOrder");
        //    }

        //   // Flight f = dal.Flights.Find(order.flightId);
        //    // f.numberOfSeats -= order.NoTicket;
        //    //dal.Entry(f).State = System.Data.Entity.EntityState.Modified;
        //    //dal.SaveChanges();

        //    return View(order);
        //}


        //public ActionResult BookOrder(string fid)
        //{
        //    Random rnd = new Random();

        //    Order order = new Order()
        //    {
        //        flightId = fid,
        //        orderId = (rnd.Next()).ToString(),




        //    };
        //    return View(order);
        //}
        //public ActionResult Payment(Order order)
        //{
        //    TempData["Order"] = order;
        //    //order.TotalPrice = totalPriceTickets(order.flightId, order.NoTicket).ToString();
        //    order.TotalPrice = (200).ToString();

        //    return View(order);
        //}
        //,string totalPrice 
        [HttpPost]
        public ActionResult Payment(string fid,string OrderID, string cardNum,string cardDate,string cvv,string custID,string noTick,string fullName, string totalPrice)
        {
           //string total;
           // Dal1 dal = new Dal1();
           // Flight flight = dal.Flights.Find(fid);
           // int priceForFlight = flight.price;
           // total = ((priceForFlight) * Convert.ToInt32(noTick)).ToString();
            Random rnd = new Random();
             Order order = new Order();
            
                    order. flightId = fid;
                    order.orderId = rnd.Next().ToString();
                    order.NoTicket = Convert.ToInt32(noTick);
                    order.TotalPrice =100.ToString();
                   
                    order.custumerId = custID;
                    order.cardDate = cardDate;
                    order.cardNumber = cardNum;
                    order.cvv = cvv;
                    order.fullName = fullName;

                
               
                     return View(order);
        }





        private int totalPriceTickets(string id, string numTic)
        {
            int total = 0;
            Dal1 dal = new Dal1();
            //var priceForFlight =
            //  (from x in dal.Flights
            //   where x.flightId.ToString().Equals(id)
            //   select Convert.ToInt32(x.price));
            Flight flight = dal.Flights.Find(id);
            int priceForFlight = flight.price;
            // string temp = (priceForFlight).ToString();
            //  int integerPrice = Convert.ToInt32(temp);

            total = (priceForFlight) * Convert.ToInt32(numTic);
            return total;
            //int price=0;
            //string sql = "Select price from tblFlight where flightId=id";
            ////System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, connection);

            ////using (SqlConnection con=new SqlConnection)
            //SqlDataReader rd = cmd.ExecuteReader();
            //if (rd.HasRows)
            //{
            //    rd.Read();
            //     price = rd.GetInt32(0);
            //}

            //return price * numTic;
        }


        [HttpPost]
        public ActionResult SummaryOrder([Bind(Include = "orderId,flightId,NoTicket,TotalPrice,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        {
            Dal1 dal = new Dal1();
            List<Order> objOrders = dal.Orders.ToList();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Order = order;

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

        public ActionResult MyOrders()
        {
            Dal1 dal = new Dal1();
            List<Order> orders = dal.Orders.ToList<Order>();
            return View(orders);
        }
         
    }
}