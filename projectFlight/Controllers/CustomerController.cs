using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using projectFlight.Models;
using projectFlight.ViewModel;
using projectFlight.Dal;

namespace projectFlight.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EnterCustomer()
        {
            return View();
        }//register

        [HttpPost]
        public ActionResult EnterCustomer(Customer customer) //register
        {
            if (ModelState.IsValid)
            {
                Dal1 dal = new Dal1();
                if (dal.Customers.Any(c => c.custId == customer.custId))
                {
                    ViewBag.Message = "The user alredy exsits";
                    return RedirectToAction("LoginCustomer", "Customer");
                }


                dal.Customers.Add(customer);
                dal.SaveChanges();
                ViewBag.Message = "Welcome";
                return RedirectToAction("Index", "Home");

            }


            return View();



        }

        public ActionResult LoginCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCustomer(Customer customer)
        {
            Dal1 dal = new Dal1();


            if (dal.Customers.Any(c => c.custId == customer.custId))//alredy exsits
            {
                return RedirectToAction("Index", "Home");
            }
            //else
            //    ViewBag.Message = "No such user,please register";
            return View();
        }
        public ActionResult Sumbit() //login or sign in
        {



            CustomerViewModel cvm = new CustomerViewModel();
            Customer objC = new Customer();
            Dal1 dal = new Dal1();
            List<Customer> listCust = dal.Customers.ToList<Customer>();

            if (Request.Form.Count > 0)
            {
                objC.firstName = Request.Form["customer.FirstName"]?.ToString();
                objC.lastName = Request.Form["customer.lastName"]?.ToString();
                objC.passportNum = Request.Form["customer.passportNum"]?.ToString();
                objC.custId = Request.Form["customer.custId"]?.ToString();
                objC.mail = Request.Form["customer.mail"]?.ToString();


                foreach (Customer c in listCust)
                {
                    if (c.custId == objC.custId)
                    {

                        cvm.Customer = c;//add the current user to the CVM user
                        Session["id"] = c.custId;
                        HomeController h = new HomeController();
                        return View("Index", h);//order 
                    }
                }

            }
            return View("EnterCustomer");


        }
        public Customer getCustomer()
        {
            Customer objC = new Customer();
            objC.firstName = Request.Form["customer.FirstName"].ToString();
            objC.lastName = Request.Form["customer.lastName"].ToString();
            objC.passportNum = Request.Form["customer.passportNum"].ToString();
            objC.custId = Request.Form["customer.custId"].ToString();
            objC.mail = Request.Form["customer.mail"].ToString();

            return objC;
        }


        [HttpGet]
        public ActionResult LoginToOrders()
        {

            Dal1 dal = new Dal1();
            List<Order> orders = dal.Orders.ToList<Order>();

            return View(orders);



        }
        public ActionResult SearchOrders()
        {
            Dal1 dal = new Dal1();


            //if (string.IsNullOrWhiteSpace(Request.Form["CustID"]))
            //{

            //    var custOrders = dal.Orders.ToList<Order>();
            //}
           
                string custID = Request.Form["CustID"]?.ToString();


                var custOrders = dal.Orders.Where(o => o.custumerId == custID);
                custOrders.ToList<Order>();
           
            return View("LoginToOrders", custOrders);
        }



    }
}