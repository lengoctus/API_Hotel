using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string Luggage { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public int RoomId { get; set; }
        public int CusId { get; set; }
        public string Address { get; set; }
        public int? NbPeople { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual Room Room { get; set; }
    }
}
