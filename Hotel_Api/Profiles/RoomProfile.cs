using Hotel_Api.Models.Entities;
using Hotel_Api.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Profiles
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
