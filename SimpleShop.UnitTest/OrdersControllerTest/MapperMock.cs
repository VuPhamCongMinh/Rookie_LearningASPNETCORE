using AutoMapper;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.UnitTest.OrdersControllerTest
{
    public class MapperMock
    {
        public static IMapper Get ()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderCreateRequest, OrderDetail>().ReverseMap();
                cfg.CreateMap<OrderResponse, Order>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
