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
using System.Text;

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
                    order.cardNumber = cardNum;
                //order.cardNumber = encryptAES(cardNum, out string keyBase64, out string vectorBase64);
           // order.cvv = DecryptDataWithAes(cardNum, string keyBase64, string vectorBase64);
                    order.cvv = cvv;
                    order.fullName = fullName;
                    
            dal.SaveChanges();
           return View(order);
        }




        //private static string encryptAES(string plainText, out string keyBase64, out string vectorBase64)
        //{


        //    using (Aes aesAlgorithm = Aes.Create())
        //    {
        //        keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
        //        vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);
        //        ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();
        //        byte[] encryptedData;

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter sw = new StreamWriter(cs))
        //                {
        //                    sw.Write(plainText);
        //                }
        //                encryptedData = ms.ToArray();
        //            }
        //        }

        //        return Convert.ToBase64String(encryptedData);

        //    }
        //}


        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        //b14ca5898a4e4133bbce2ea2315a1916
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        //private static string DecryptDataWithAes(string cipherText, string keyBase64, string vectorBase64)
        //{

        //    using (Aes aesAlgorithm = Aes.Create())
        //    {
        //        aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
        //        aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);

        //        Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
        //        Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
        //        Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
        //        Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");

        //        // Create decryptor object
        //        ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

        //        byte[] cipher = Convert.FromBase64String(cipherText);

        //        //Decryption will be done in a memory stream through a CryptoStream object
        //        using (MemoryStream ms = new MemoryStream(cipher))
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader sr = new StreamReader(cs))
        //                {
        //                    return sr.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}

        [HttpPost]
        public ActionResult SummaryOrder([Bind(Include = "orderId,flightId,NoTicket,TotalPrice,custumerId,cardNumber,cardDate,cvv,fullName")] Order order)
        {


            string keyNumber = System.Configuration.ConfigurationManager.AppSettings["aes"];
            string keyCvv= System.Configuration.ConfigurationManager.AppSettings["aesCvv"];

          




            Dal1 dal = new Dal1();
            dal.Database.ExecuteSqlCommand("SET ANSI_WARNINGS OFF");
            List<Order> objOrders = dal.Orders.ToList();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Order = order;
           
            order.cardNumber = (EncryptString(order.cardNumber,  keyNumber)).Substring(0,order.cardNumber.Length);
            //order.cardDate = (EncryptString(order.cardDate, keyNumber)).Substring(0, order.cardDate.Length);
            order.cvv = (EncryptString(order.cvv, keyCvv)).Substring(0, order.cvv.Length);
           
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


