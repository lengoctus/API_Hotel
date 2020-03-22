using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Bill = new HashSet<Bill>();
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int? IdCard { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
