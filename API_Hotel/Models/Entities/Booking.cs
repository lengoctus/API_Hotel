using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int? IdCard { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
