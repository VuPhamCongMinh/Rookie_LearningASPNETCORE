using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.API.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile ()
        {
            CreateMap<OrderCreateRequest, OrderDetail>().ReverseMap();
        }
    }
}
