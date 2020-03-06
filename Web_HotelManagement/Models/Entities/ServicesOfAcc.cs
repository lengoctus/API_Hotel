using System;
using System.Collections.Generic;

namespace Web_HotelManagement.Models.Entities
{
    public partial class ServicesOfAcc
    {
        public int IdAccount { get; set; }
        public int IdServices { get; set; }
        public DateTime? DateStart { get; set; }
        public string Description { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual ListServices IdServicesNavigation { get; set; }
    }
}
