using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class Customer_View
    {
        public int Id { get; set; }

        //[Required(ErrorMessage ="FullName is required!!")]
        public string FullName { get; set; }

        public string Country { get; set; }

        public int IdCard { get; set; }

        public bool Gender { get; set; }

        //[Required(ErrorMessage = "Email is required!!")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Address is required!!")]
        public string Address { get; set; }

        public DateTime Date { get; set; }

        //[Required(ErrorMessage = "Phone is required!!")]
        public string Phone { get; set; }
        public string Password { get; set; }

        public Booking_View Booking_View { get; set; }

    }
}
