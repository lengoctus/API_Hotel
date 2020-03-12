using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Accommodation
    {
        public int Id { get; set; }
        public string AccName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalAmount { get; set; }
        public int AccCategory { get; set; }
        public bool? Service { get; set; }
        public bool? Status { get; set; }

        public virtual AccommodationCategory AccCategoryNavigation { get; set; }
        public virtual Meals Id1 { get; set; }
        public virtual Booking IdNavigation { get; set; }
    }
}
