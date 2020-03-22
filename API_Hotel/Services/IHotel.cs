using API_Hotel.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public interface IHotel
    {

        /// <summary>
        /// Get list Customer by FullName or Phone
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Phone"></param>
        /// <returns></returns>
        Task<List<Customer>> Gets(string FullName, string Phone);

        /// <summary>
        /// Update Info Customer
        /// </summary>
        /// <param name="CusId"></param>
        /// <returns></returns>
        Task<bool> UpdateInfo(int CusId, Customer Cus, IMapper mapper);


        /// <summary>
        /// Login with Phone and Password
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<Customer> Login(string Phone, string Password);
    }
}
