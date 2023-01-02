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
        [Display(Name = "ID:")]
        [Required(ErrorMessage = "The ID field is required")]
        public string custId { get; set; }

        [Required(ErrorMessage = "The first name field is required")]
        [Display(Name = "First name:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must have 3 letters at least , and 50 letters at most")]
        public string firstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last name:")]
        [Required(ErrorMessage = "The last name field is required")]
        public string lastName { get; set; }

        [StringLength(50)]
        [Display(Name = "mail:")]
        [Required(ErrorMessage = "The email field is required")]
        //[RegularExpression(@"^[\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "The mail is not as excpected!")]
        public string mail { get; set; }

        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Passport number:")]
        [Required(ErrorMessage = "The Passport number field is required")]
        
        public string passportNum { get; set; }

    }
    }