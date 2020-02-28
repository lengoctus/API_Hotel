using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Models.ModelViews
{
    public class Booking_View
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int  IdCard { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
