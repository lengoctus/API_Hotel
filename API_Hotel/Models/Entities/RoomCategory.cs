using System;
using System.Collections.Generic;

namespace API_Hotel.Models.Entities
{
    public partial class RoomCategory
    {
        public RoomCategory()
        {
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Charge { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
