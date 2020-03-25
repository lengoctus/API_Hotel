using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models.ModelsView
{
    public class InfoBooking
    {
        public List<Booking_View> bookingSourse { get; set; }
        public Booking_View Booking { get; set; }
        public List<Room_View> RoomSourse { get; set; }
    }
}
