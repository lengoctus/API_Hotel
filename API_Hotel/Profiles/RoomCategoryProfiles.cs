using API_Hotel.Models.Entities;
using API_Hotel.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Hotel.Profiles
{
    public class RoomCategoryProfiles : Profile
    {
        public RoomCategoryProfiles()
        {
            // From Entities - ModelsView
            CreateMap<RoomCategory, RoomCategory_View>();

            // From ModelsView - Entities
            CreateMap<RoomCategory_View, RoomCategory>();
        }
    }
}
