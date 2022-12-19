using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectFlight.Models
{
    public class Customer
    {
        [Key]
        [StringLength(10)]
        public string custId { get; set; }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string mail { get; set; }
        [StringLength(50)]
        public string passportNum { get; set; }


    }
}