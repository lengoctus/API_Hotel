using Hotel_Api.Models.Entities;
using AutoMapper;
using Hotel_Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Services
{
    public interface IHotel
    {
        //========================= Customer ====================
        /// <summary>
        /// Get list Customer by FullName or Phone
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="Phone"></param>
        /// <returns></returns>
        Task<List<Customer>> Gets(string FullName, string Phone);

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Customer> AddCustomer(Customer customer);

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

        //========================= Room Category =====================
        /// <summary>
        /// Get Room Category 
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        Task<List<RoomCategory>> GetRoomCategory(int? idCategory);

        /// <summary>
        /// Add Room Category
        /// </summary>
        /// <param name="roomCate"></param>
        /// <returns></returns>
        Task<RoomCategory> PostRoomCategory(RoomCategory roomCate);

        //========================= Booking =====================
        /// <summary>
        /// Get Booking
        /// </summary>
        /// <param name="Cusid"></param>
        /// <returns></returns>
        Task<List<Booking>> GetBooking(int? Cusid);

        /// <summary>
        /// Get Room for Booking
        /// </summary>
        /// <param name="bookingSourse"></param>
        /// <param name="booking"></param>
        /// <param name="RoomSourse"></param>
        /// <returns></returns>
        Task<List<Room>> BookingRoom(List<Booking> bookingSourse, Booking booking, List<Room> RoomSourse);

        /// <summary>
        /// Add Booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        Task<Booking> AddBooking(Booking booking);
    }
}
