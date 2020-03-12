using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Meals
    {
        public Meals()
        {
            Accommodation = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Charge { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? AccId { get; set; }
        public int? IdCard { get; set; }

        public virtual ICollection<Accommodation> Accommodation { get; set; }
    }
}
