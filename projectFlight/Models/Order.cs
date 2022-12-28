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
        public string orderId { get; set; }

        [Required]
        [StringLength(50)]
        
        public string flightId { get; set; }

      
        public int NoTicket { get; set; }

        [Required]
        [StringLength(50)]
        public string TotalPrice { get; set; }

       

        [StringLength(10)]
 
        public string custumerId { get; set; }

        [StringLength(16)]
        public string cardNumber { get; set; }

        [StringLength(5)]
        public string cardDate { get; set; }

        [StringLength(3)]
        public string cvv { get; set; }
        [StringLength(50)]
        public string fullName { get; set; }
        public virtual Flight Flight { get; set; }
    }
}