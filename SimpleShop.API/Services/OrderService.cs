using AutoMapper;
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
        public async Task<Order> PostOrderAsync (OrderCreateRequest order, string userId)
        {
            Order orderToBeAdded;
            var productInDB = await context.Products.FindAsync(order.productId);

            if (!context.Orders.Any(o => o.user.Id == userId))
            {
                var orderDetail = mapper.Map<OrderDetail>(order);
                orderToBeAdded = new Order { orderId = Guid.NewGuid().ToString(), userId = userId };
                orderToBeAdded.updatedDate = orderToBeAdded.createdDate = DateTime.Now;
                orderDetail.orderId = orderToBeAdded.orderId;
                orderToBeAdded.orderDetails = new List<OrderDetail>() { orderDetail };
                context.Orders.Add(orderToBeAdded);
            }
            else
            {
                orderToBeAdded = await context.Orders.Where(o => o.user.Id == userId).Include(o => o.orderDetails).FirstOrDefaultAsync();
                AddToCart(ref orderToBeAdded, order);
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

        private void AddToCart (ref Order order, OrderCreateRequest orderCreateRequest)
        {
            var productExistOrder = order.orderDetails.Where(x => x.productId == orderCreateRequest.productId).FirstOrDefault();
            if (productExistOrder != null)
            {
                if (productExistOrder.quantity + orderCreateRequest.quantity <= 0)
                {
                    order.orderDetails.Remove(productExistOrder);
                }
                else
                {
                    productExistOrder.quantity += orderCreateRequest.quantity;
                }
            }
            else
            {
                productExistOrder = new OrderDetail { productId = orderCreateRequest.productId, quantity = orderCreateRequest.quantity, orderId = order.orderId };
                order.updatedDate = order.createdDate = DateTime.Now;
                order.orderDetails.Add(productExistOrder);
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetUserOrderDetailAsync (string userId)
        {
            if (context.Orders.Any(o => o.userId == userId))
            {
                var userOrder = context.Orders.First(o => o.userId == userId);

                return await context.OrderDetails.Where(od => od.orderId == userOrder.orderId).Include(od => od.Product).ThenInclude(p => p.Images).ToListAsync();
            }

            else
            {
                return null;
            }
        }
        public int CountUserOrderAsync (string userId)
        {
            var userOrder = context.Orders.Where(o => o.userId == userId).Include(o => o.orderDetails).ThenInclude(od => od.Product).FirstOrDefault().orderDetails.Count();
            return userOrder;
        }

        public async Task<IEnumerable<Order>> GetOrders ()
        {
            try
            {
                return await context.Orders.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Order> GetOrder (string id)
        {
            try
            {
                return (await context.Orders.Where(x => x.orderId == id).FirstAsync());
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
