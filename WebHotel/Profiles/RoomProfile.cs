﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, Room_View>().ForMember(
                dept => dept.CategoryName,
                opt => opt.MapFrom(p => p.RoomCategoryNavigation.Name)
                );
            CreateMap<Room_View, Room>();

        }
    }
}
