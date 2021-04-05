using AutoMapper;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile ()
        {
            CreateMap<ProductPostRequest, Product>().ReverseMap();
        }
    }
}
