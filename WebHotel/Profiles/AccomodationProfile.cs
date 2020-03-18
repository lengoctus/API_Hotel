using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotel.Models.Entities;
using WebHotel.Models.ModelsView;

namespace WebHotel.Profiles
{
    public class AccomodationProfile : Profile
    {
        public AccomodationProfile()
        {
            CreateMap<Accommodation, Accomodation_View>();
            CreateMap<Accomodation_View, Accommodation>();

        }
    }
}
