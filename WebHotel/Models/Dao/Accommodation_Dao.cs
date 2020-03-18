using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;


namespace WebHotel.Models.Dao
{
    public class Accommodation_Dao
    {
        private readonly HotelManagementContext _db;

        public Accommodation_Dao()
        {
            _db = new HotelManagementContext();
        }

        public List<Accommodation> GetAccomo()
        {
            var list = _db.Accommodation.ToList();
            return list;
        }
    }
}
