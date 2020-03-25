using System;
using System.Collections.Generic;

namespace Hotel_Api.Models.Entities
{
    public partial class ListServices
    {
        public ListServices()
        {
            ServiceOfAcc = new HashSet<ServiceOfAcc>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Func { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ServiceOfAcc> ServiceOfAcc { get; set; }
    }
}
