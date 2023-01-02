using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectFlight.Models
{
    public class Order
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Order ID:")]
        public string orderId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Flight ID:")]
        public string flightId { get; set; }

        [Display(Name = "Number of tickets:")]
        public int NoTicket { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Total Price:")]
        public string TotalPrice { get; set; }

       

        [StringLength(10)]
        [Display(Name = "ID:")]
        public string custumerId { get; set; }

        [StringLength(16,MinimumLength =10,ErrorMessage ="Please enter a vailid credit card number")]
        [Display(Name = "Credit Card Number:")]
        public string cardNumber { get; set; }

        [StringLength(5, MinimumLength = 4, ErrorMessage = "Please enter a vailid credir card date")]
        [Display(Name = "Credit Card Date:")]
        public string cardDate { get; set; }

        [StringLength(3, MinimumLength=3, ErrorMessage = "Please enter a vailid credir card cvv")]
        [Display(Name = "Credit cvv:")]
        public string cvv { get; set; }

        [StringLength(50)]
        [Display(Name = "Full Name :")]
        public string fullName { get; set; }


        public virtual Flight Flight { get; set; }
    }
}