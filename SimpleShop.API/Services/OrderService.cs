using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Shared.EF;
using SimpleShop.Shared.Interfaces;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyDBContext context;
        private readonly IMapper mapper;

        public OrderService (MyDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Order> PostOrder (OrderCreateRequest order, string userId)
        {
            Order orderToBeAdded;
            var productInDB = await context.Products.FindAsync(order.productId);

            if (!context.Orders.Any(o => o.user.Id == userId))
            {
                var orderDetail = mapper.Map<OrderDetail>(order);
                orderDetail.Product = productInDB;
                orderToBeAdded = new Order { orderId = Guid.NewGuid().ToString(), userId = userId, createdDate = DateTime.Now, updatedDate = DateTime.Now };
                orderToBeAdded.orderDetails = new List<OrderDetail>();
                orderDetail.orderId = orderToBeAdded.orderId;
                orderDetail.Order = orderToBeAdded;
                orderToBeAdded.orderDetails.Add(orderDetail);
                context.Orders.Add(orderToBeAdded);
            }
            else
            {
                orderToBeAdded = await context.Orders.Where(o => o.user.Id == userId).Include(o => o.orderDetails).FirstOrDefaultAsync();
                var orderDetail = mapper.Map<OrderDetail>(order);
                orderDetail.Product = productInDB;
                orderDetail.orderId = orderToBeAdded.orderId;
                orderDetail.Order = orderToBeAdded;
                orderToBeAdded.orderDetails.Add(orderDetail);
            }

            try
            {

                await context.SaveChangesAsync();
                return orderToBeAdded;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
