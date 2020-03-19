using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Models.Dao
{
    public class BookingRoom_Dao
    {
        private readonly HotelManagementContext _db;

        public BookingRoom_Dao()
        {
            _db = new HotelManagementContext();
        }

        public List<Booking> GetListRoomForBooking(Booking book)
        {
            var listRoom = _db.Booking.Where(p => p.OutDate < book.InDate).Select(p => p.RoomId).Distinct().ToList();

            var Rm = _db.Room.Where(p => !listRoom.Contains(p.Id)).ToList();
            return null;
        }
    }
}
