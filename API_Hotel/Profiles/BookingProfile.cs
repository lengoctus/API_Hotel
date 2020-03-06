using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Convert from Booking to Booking_View
            CreateMap<Models.Entities.Booking, Models.ModelViews.Booking_View>();

            // Convert from Booking_View to Booking
            CreateMap<Models.ModelViews.Booking_View, Models.Entities.Booking>();
        }
    }
}
