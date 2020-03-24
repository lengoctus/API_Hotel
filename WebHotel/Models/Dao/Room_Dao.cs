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

        public Room_Dao(HotelManagementContext db)
        {
            _db = db;
        }

        public List<Room> GetAccomo()
        {
            var list = _db.Room.ToList();
            return list;
        }

        public Room GetRoom(int id)
        {
            if (id != 0)
            {
                try
                {
                    var room = _db.Room.SingleOrDefault(p => p.Id == id);
                    return room;
                }
                catch
                {

                    return null;
                }
            }
            return null;
        }
    }
}
