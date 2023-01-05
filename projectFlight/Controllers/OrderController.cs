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
using System.IO;
using System.Security.Cryptography;


namespace projectFlight.Controllers
{
    public class OrderController : Controller
    {


       

        [HttpPost]
        public ActionResult Payment(string fid,string fprice,string OrderID, string cardNum,string cardDate,string cvv,string custID,string noTick,string fullName, string totalPrice, string creditCardSave)
        {
          
            Dal1 dal = new Dal1();
            Flight flight = dal.Flights.Find(fid);
            Random rnd = new Random();
            Order order = new Order();
          
                    order. flightId = fid;
                    order.orderId = rnd.Next().ToString();
            if (flight.numberOfSeats >= Convert.ToInt32(noTick))
                order.NoTicket = Convert.ToInt32(noTick);
            else
                ViewBag["error"] = "cannot book this number os seats";


            
                    order.TotalPrice = fprice;
                    order.custumerId = custID;
                    order.cardDate = cardDate;


            //string enc = encryptAES(cardNum, out string keyBase64, out string vectorBase64);
            //order.cardNumber = enc;
            order.cardNumber = cardNum;
                    order.cvv = cvv;
                    order.fullName = fullName;
                    //string plainText = cardNum;
                    //order.cardNumber = encryptAES(plainText, out string keyBase64, out string vectorBase64);

            dal.SaveChanges();
           return View(order);
        }

        //string plainText = cardNum;
        //order.cardNumber = encryptAES(plainText, out string keyBase64, out string vectorBase64);



        private static string encryptAES(string plainText, out string keyBase64, out string vectorBase64)
        {


            using (Aes aesAlgorithm = Aes.Create())
            {
                keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
                vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();
                byte[] encryptedData;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encryptedData = ms.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedData);

            }
        }

        private static string DecryptDataWithAes(string cipherText, string keyBase64, string vectorBase64)
        {

            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
                aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);

                Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
                Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
                Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
                Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");

                // Create decryptor object
                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

                byte[] cipher = Convert.FromBase64String(cipherText);

                //Decryption will be done in a memory stream through a CryptoStream object
                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult SummaryOrder([Bind(Include = "orderId,flightId,NoTicket,TotalPrice,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        {
            //string enc = encryptAES(order.cardNumber, out string keyBase64, out string vectorBase64);
            //order.cardNumber = enc;
            //order.cardNumberKey = keyBase64;
            //order.cardNumberVector = vectorBase64;


            Dal1 dal = new Dal1();
            dal.Database.ExecuteSqlCommand("SET ANSI_WARNINGS OFF");
            List<Order> objOrders = dal.Orders.ToList();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Order = order;
           // string enc = encryptAES(order.cardNumber, out string keyBase64, out string vectorBase64);
            //dal.Database.ExecuteSqlCommand("SET ANSI_WARNINGS OFF");



            order.cardNumber = (encryptAES(order.cardNumber, out string keyBase64, out string vectorBase64)).Substring(0,order.cardNumber.Length);
            //dal.Database.ExecuteSqlCommand("SET ANSI_WARNINGS ON");
            if (ModelState.IsValid)
            {
             
               
               
                // order.cardNumber = encryptAES(order.cardNumber, out string keyBase64, out string vectorBase64);
                dal.Orders.Add(order);
                dal.SaveChanges();
              

            }
            //dal.Database.ExecuteSqlCommand("SET ANSI_WARNINGS ON");
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


