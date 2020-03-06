using System;
using System.Collections.Generic;

namespace Web_HotelManagement.Models.Entities
{
    public partial class Account
    {
        public Account()
        {
            Invoice = new HashSet<Invoice>();
            ServicesOfAcc = new HashSet<ServicesOfAcc>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<ServicesOfAcc> ServicesOfAcc { get; set; }
    }
}
