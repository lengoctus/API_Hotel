using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles()
        {
            // Convert from Customer to Customer_View
            CreateMap<Models.Entities.Customer, Models.ModelViews.Customer_View>();

            // Convert from Customer_View to Customer
            CreateMap<Models.ModelViews.Customer_View, Models.Entities.Customer>();

            // Convert from Customer to Customer
            CreateMap<Models.Entities.Customer, Models.Entities.Customer>().ForMember(
                dept => dept.Id,
                opt => opt.Ignore());
        }
    }
}
