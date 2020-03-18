using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Meals
    {
        public Meals()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Charge { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
