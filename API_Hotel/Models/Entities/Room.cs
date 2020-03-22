using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalAmount { get; set; }
        public int RoomCategory { get; set; }
        public bool? IsService { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }

        public virtual RoomCategory RoomCategoryNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
