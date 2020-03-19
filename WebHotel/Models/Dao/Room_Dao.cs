using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;


namespace WebHotel.Models.Dao
{
    public class Room_Dao
    {
        private readonly HotelManagementContext _db;

        public Room_Dao()
        {
            _db = new HotelManagementContext();
        }

        public List<Room> GetAccomo()
        {
            var list = _db.Room.ToList();
            return list;
        }
    }
}
