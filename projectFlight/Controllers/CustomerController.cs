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
            Dal1 dal = new Dal1();
            List<Customer> objCustomers = dal.Customers.ToList<Customer>();
            CustomerViewModel cvm = new CustomerViewModel();
            cvm.Customer = new Customer();
            cvm.Customers = objCustomers;
            return View(cvm);
        }

        public ActionResult Sumbit()
        {
            //Customer cust = new Customer();
            //cust.FirstName = Request.Form["FirstName"];
            //cust.lastName = Request.Form["lastName"];
            //cust.CustomerNum = Request.Form["CustomerNum"];
            Customer myCustomer = new Customer();
            CustomerViewModel cvm = new CustomerViewModel();
            Dal1 dal = new Dal1();
            if (ModelState.IsValid)
            {

                //dal.Customers1.Add(cust);
                dal.Customers.Add(getCustomer());
                dal.SaveChanges();
                return View("Customer", myCustomer);

            }
            else
                cvm.Customer = getCustomer();
            cvm.Customers = dal.Customers.ToList<Customer>();
            return View("EnterCustomer", cvm);
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


    }
}