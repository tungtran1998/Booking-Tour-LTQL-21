using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Users
    {

        [Key]
        public int id { get; set; }
        [Required, MaxLength(30)]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter your email"), EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Compare("password")]
        public string confirmPassword { get; set; }
        [MaxLength(255)]
        public string avatar { get; set; }
        public bool role { get; set; }
        public ICollection<Bills> Bills { get; set; }
    }
}