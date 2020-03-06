using System;
using System.Collections.Generic;

namespace Web_HotelManagement.Models.Entities
{
    public partial class AccommodationCategory
    {
        public AccommodationCategory()
        {
            Accommodation = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Charge { get; set; }

        public virtual ICollection<Accommodation> Accommodation { get; set; }
    }
}
