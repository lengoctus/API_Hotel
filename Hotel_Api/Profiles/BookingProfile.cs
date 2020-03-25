using Hotel_Api.Models.Entities;
using Hotel_Api.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Api.Models.ModelsView;

namespace Hotel_Api.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, Booking_View>();
            CreateMap<Booking_View, Booking>();
        }
    }
}
