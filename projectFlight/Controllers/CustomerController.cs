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
                if (dal.Customers.Any(c=>c.custId==customer.custId))
                {
                    ViewBag.Message = "The user alredy exsits";
                    return RedirectToAction("LoginCustomer", "Customer");
                }
                //foreach (Customer C in dal.Customers)
                //{
                //    if(C.custId.ToString().Equals(customer.custId))
                //    {
                //        ViewBag.Message = "The user alredy exsits";
                //        return View();
                //    }
                //}

                dal.Customers.Add(customer);
                dal.SaveChanges();
                ViewBag.Message = "Welcome";
                return RedirectToAction("Index", "Home");

            }
            
         
            return View();

            //CustomerViewModel cvm = new CustomerViewModel();
            //Customer objC = new Customer();
            //Dal1 dal = new Dal1();
            //List<Customer> listCust = dal.Customers.ToList<Customer>();

            //if(Request.Form.Count>0)
            //{
            //    objC.firstName = Request.Form["customer.FirstName"]?.ToString();
            //    objC.lastName = Request.Form["customer.lastName"]?.ToString();
            //    objC.passportNum = Request.Form["customer.passportNum"]?.ToString();
            //    objC.custId = Request.Form["customer.custId"]?.ToString();
            //    objC.mail = Request.Form["customer.mail"]?.ToString();


            //    foreach(Customer c in listCust)
            //    {
            //        if(c.custId==objC.custId )
            //        {
            //            cvm.Customer = c;//add the current user to the CVM user
            //            HomeController h = new HomeController();
            //            return View("Index",h);//order 
            //        }
            //    }

            //}
            //return View("EnterCustomer");

        }

        public ActionResult LoginCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCustomer(Customer customer)
        {
            Dal1 dal = new Dal1();

            //var ifExs = dal.Customers.Find(customer.custId);
            //if (ifExs != null)
            //{
            //    RedirectToAction("Index", "Home");
            //}
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
            //Customer cust = new Customer();
            //cust.FirstName = Request.Form["FirstName"];
            //cust.lastName = Request.Form["lastName"];
            //cust.CustomerNum = Request.Form["CustomerNum"];
            //HomeController h = new HomeController();
            //Customer myCustomer = new Customer();
            //CustomerViewModel cvm = new CustomerViewModel();
            //Dal1 dal = new Dal1();
            //if (ModelState.IsValid)
            //{

            //    //dal.Customers1.Add(cust);
            //    dal.Customers.Add(getCustomer());
            //    dal.SaveChanges();

            //    return View("Index", h);//order 
            //    //return View("Customer", myCustomer);

            //}
            //else
            //    cvm.Customer = getCustomer();
            //cvm.Customers = dal.Customers.ToList<Customer>();

            ////HomeController h = new HomeController();
            //return View("Index", h);//order 


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
            objC.custId= Request.Form["customer.custId"].ToString();
            objC.mail = Request.Form["customer.mail"].ToString();

            return objC;
        }

        //public ActionResult BookOrder(string id)
        //{
        //    return View();
        //}
        public ActionResult LoginToOrders()
        {
            Dal1 dal = new Dal1();
            List<Customer> objCustomers = dal.Customers.ToList<Customer>();
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.Customer = new Customer();
            cvm.Customers = objCustomers;
            return View(cvm);
        }

            public ActionResult Search()
        {
           string  firstName = Request.Form["firstName"]?.ToString();
           string lastName = Request.Form["lastName"]?.ToString();
           string id = Request.Form["CustID"]?.ToString();

         
            Dal1 dal = new Dal1();
            List<Customer> listCust = dal.Customers.ToList<Customer>();

            foreach (Customer c in listCust)
            {
                if(c.lastName.Equals(lastName) && c.firstName.Equals(firstName)
                    && c.custId.Equals(id))
                {
                    return View("MyOrders");
                }
            }

            ViewBag.UserORPassError = "No orders yet..";
            return View("EnterCustomer");

        }

        public ActionResult MyOrders()
        {
            Dal1 dal = new Dal1();
            List<Customer> objCustomers = dal.Customers.ToList<Customer>();
            List<Order> objOrders = dal.Orders.ToList<Order>();
            CustomerViewModel cvm = new CustomerViewModel();
            OrderViewModel avm = new OrderViewModel();
            avm.Order = new Order();
            avm.Orders = objOrders;
            cvm.Customer = new Customer();
            cvm.Customers = objCustomers;
            return View(avm);
        }

        public ActionResult ShowSearrch()
        {
            OrderViewModel avm = new OrderViewModel();
            avm.Orders = new List<Order>();
            return View("MyOrders", avm);
        }


        

        //public ActionResult MyOrders(OrderViewModel orderModel)
        //{
        //    Dal1 dal = new Dal1();
        //    List<Order> listOrders = dal.Orders.ToList<Order>();
        //    bool flag = false;
        //    string id = Session["CustID"].ToString();
        //    foreach (Order o in listOrders)
        //    {
        //        if (o.custumerId.Equals(id))
        //        {
        //            flag = true;
        //        }
        //    }
        //    List<Order> ord = (from x in dal.Orders
        //                       where x.custumerId == id
        //                       select x).ToList<Order>();
        
        //OrderViewModel avm = new OrderViewModel();
        //    avm.Orders = ord;


        //    return View(ord);
        //}


    }
}