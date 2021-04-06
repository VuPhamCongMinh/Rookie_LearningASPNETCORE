using AutoMapper;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.Profiles
{
    public class RatingProfile : AutoMapper.Profile
    {
        public RatingProfile ()
        {
            CreateMap<RatingResponse, Rating>().ReverseMap();
        }
    }
}
