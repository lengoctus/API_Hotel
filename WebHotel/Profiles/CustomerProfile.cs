using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, Customer_View>();
            CreateMap<Customer_View, Customer>();
            CreateMap<Customer, Customer_View> ().ForMember(
                dept => dept.Booking_View,
                opt => opt.Ignore()
                );
        }
    }
}
