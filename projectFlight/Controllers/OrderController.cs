using projectFlight.Models;
using projectFlight.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Load()

        {
            Order myOrder = new Order
            {
                flightId = Session["flightIdValue"]?.ToString(),
                orderId = "1"
                ,
                NoTicket = 1,
                TotalPrice = Session["flightPriceValue"]?.ToString(),
                seatNumber = "1a",
                custumerId = Session["CustIdVal"]?.ToString(),
                cardDate = "09/29",
                cvv="123"


            };
            return View("BookOrder", myOrder);
        }

        [HttpPost]
        public ActionResult BookOrder(OrderViewModel orderModel)
        {
            if (ModelState.IsValid)
            {
                Session["SelectedValue"] = orderModel;
               // return RedirectToAction("Index", "Payment", new { model = orderModel });
            }
           


            orderModel.Order.flightId = Session["flightIdValue"]?.ToString();
            int totPrice=Convert.ToInt32( Session["flightPriceValue"]?.ToString());
            orderModel.Order.TotalPrice = totPrice.ToString();
         

            return View(orderModel);
        }
    }
}