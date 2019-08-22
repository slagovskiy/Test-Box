using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace teach01.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Yes or No?")]
        public bool? WillAttend { get; set; }
    }
}
