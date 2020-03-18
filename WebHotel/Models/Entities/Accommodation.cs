using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Accommodation
    {
        public Accommodation()
        {
            Booking = new HashSet<Booking>();
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string AccName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalAmount { get; set; }
        public int AccCategory { get; set; }
        public bool? IsService { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }

        public virtual AccommodationCategory AccCategoryNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
