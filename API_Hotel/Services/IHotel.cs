using API_Hotel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public interface IHotel
    {
        /// <summary>
        /// Get list Booking
        /// </summary>
        /// <returns></returns>
        Task<List<Booking>> Gets();

        /// <summary>
        /// Get Booking by phone
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<Booking> Get(string phone);

    }
}
