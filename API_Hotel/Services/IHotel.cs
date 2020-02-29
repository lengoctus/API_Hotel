using API_Hotel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public interface IHotel
    {
        Task<List<Booking>> GetList();
        Task<Booking> RegisterBooking(Booking book);
    }
}
