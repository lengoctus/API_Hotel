using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Account
    {
        public Account()
        {
            Invoice = new HashSet<Invoice>();
            ServiceOfAcc = new HashSet<ServiceOfAcc>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<ServiceOfAcc> ServiceOfAcc { get; set; }
    }
}
