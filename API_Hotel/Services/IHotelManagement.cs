using API_Hotel.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Services
{
    public interface IHotelManagement
    {
        Task<IEnumerable<Account_View>> GetListAccount();
        Task<IEnumerable<Booking_View>> GetListBooking();
        Task<Booking_View> GetBookingByUserName(string phone, string password);
        Task<Booking_View> RegisterBooking(Booking_View booking_view);
    }
}
