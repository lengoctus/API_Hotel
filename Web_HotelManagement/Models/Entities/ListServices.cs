using System;
using System.Collections.Generic;

namespace Web_HotelManagement.Models.Entities
{
    public partial class ListServices
    {
        public ListServices()
        {
            ServicesOfAcc = new HashSet<ServicesOfAcc>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Func { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ServicesOfAcc> ServicesOfAcc { get; set; }
    }
}
