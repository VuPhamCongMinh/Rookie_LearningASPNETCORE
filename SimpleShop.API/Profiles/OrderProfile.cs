using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;

namespace SimpleShop.API.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile ()
        {
            CreateMap<OrderCreateRequest, OrderDetail>().ReverseMap();
            CreateMap<OrderResponse, Order>().ReverseMap();
        }
    }
}
