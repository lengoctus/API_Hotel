using Hotel_Api.Models.Entities;
using Hotel_Api.Models.ModelViews;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Api.Profiles
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
