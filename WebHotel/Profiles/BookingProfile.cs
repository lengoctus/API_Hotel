using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, Booking_View>();
            CreateMap<Booking_View, Booking>();
            CreateMap<Booking_View, Booking>().ForMember(
                dept => dept.Id,
                opt => opt.Ignore()
                );
        }
    }
}
