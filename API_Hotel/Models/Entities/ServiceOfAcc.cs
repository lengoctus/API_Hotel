using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class ServiceOfAcc
    {
        public int IdAccount { get; set; }
        public int IdServices { get; set; }
        public DateTime? DateStart { get; set; }
        public string Description { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual ListServices IdServicesNavigation { get; set; }
    }
}
