using System;
using System.Collections.Generic;

namespace WebHotel.Models.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            Accommodation = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string Luggage { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public int? AccId { get; set; }
        public int? CusId { get; set; }
        public string Address { get; set; }
        public int? NbPeople { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual ICollection<Accommodation> Accommodation { get; set; }
    }
}
