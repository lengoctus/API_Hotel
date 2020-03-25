using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, Room_View>();
            CreateMap<Room_View, Room>();
        }
    }
}
