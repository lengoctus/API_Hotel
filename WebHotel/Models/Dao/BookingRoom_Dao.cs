using AutoMapper;
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

        public BookingRoom_Dao(HotelManagementContext db)
        {
            _db = db;
        }

        public async Task<List<Room_View>> GetListRoomForBooking(Booking book, IMapper _mapper)
        {
            // Danh sach cac phong da duoc thue
            var phongduocthue = _db.Booking.Where(p => p.OutDate >= book.InDate).GroupBy(p => p.RoomId).Select(p => p.Key).ToList();

            // Danh sach cac phong khach tra va chua duoc thue
            var phongtrong = _db.Room.Where(p => !phongduocthue.Contains(p.Id)).ToList();

            var phongtrong_2 = new List<Room_View>(_mapper.Map<List<Room_View>>(phongtrong));
            return phongtrong_2;
        }

        public async Task<bool> AddBooking(Booking book)
        {
            try
            {
                _db.Booking.Add(book);
                int a = _db.SaveChanges();
                return a > 0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}