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
        /// Get list Booking by FullName or Phone
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Phone"></param>
        /// <returns></returns>
        Task<List<Booking>> Gets(string FullName, string Phone);

        /// <summary>
        /// Register Account for User
        /// </summary>
        /// <returns></returns>
        Task<bool> Add(Booking acc);

    }
}
