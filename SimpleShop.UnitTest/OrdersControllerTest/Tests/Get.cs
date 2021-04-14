using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.Shared.ViewModels;
using SimpleShop.UnitTest.MockData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.OrdersControllerTest.Tests
{
    public class Get : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Get (SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async void GetAll_Success ()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();

            var user = NewDatas.NewUser();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product1 = NewDatas.NewProduct();
            var product2 = NewDatas.NewProduct();
            var product3 = NewDatas.NewProduct();
            await dbContext.Products.AddRangeAsync(product1, product2, product3);
            await dbContext.SaveChangesAsync();
           
            #region create intial order data
            var order = NewDatas.NewOrder();
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            var orderDetail1 = NewDatas.NewOrderDetail();
            orderDetail1.productId = product1.productId;
            orderDetail1.orderId = order.orderId;
            var orderDetail2 = NewDatas.NewOrderDetail();
            orderDetail2.productId = product2.productId;
            orderDetail2.orderId = order.orderId;
            var orderDetail3 = NewDatas.NewOrderDetail();
            orderDetail3.productId = product3.productId;
            orderDetail3.orderId = order.orderId;
            await dbContext.OrderDetails.AddRangeAsync(orderDetail1, orderDetail2, orderDetail3);
            await dbContext.SaveChangesAsync();

            order.orderDetails = new List<OrderDetail> { orderDetail1, orderDetail2, orderDetail3 };
            order.user = user;
            await dbContext.SaveChangesAsync();
            #endregion
            var ordersService = new OrderService(dbContext, mapper);
            var ordersController = new OrdersController(ordersService, mapper);
            // Act
            var result = await ordersController.GetOrders();
            // Assert
            var ordersResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotEmpty(ordersResult.Value as IEnumerable<OrderResponse>);

        }
        [Fact]
        public async Task GetSingle_Success ()
        {
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();

            var user = NewDatas.NewUser();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product1 = NewDatas.NewProduct();
            var product2 = NewDatas.NewProduct();
            var product3 = NewDatas.NewProduct();
            await dbContext.Products.AddRangeAsync(product1, product2, product3);
            await dbContext.SaveChangesAsync();

            var order = NewDatas.NewOrder();
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            var orderDetail1 = NewDatas.NewOrderDetail();
            orderDetail1.productId = product1.productId;
            orderDetail1.orderId = order.orderId;
            var orderDetail2 = NewDatas.NewOrderDetail();
            orderDetail2.productId = product2.productId;
            orderDetail2.orderId = order.orderId;
            var orderDetail3 = NewDatas.NewOrderDetail();
            orderDetail3.productId = product3.productId;
            orderDetail3.orderId = order.orderId;
            await dbContext.OrderDetails.AddRangeAsync(orderDetail1, orderDetail2, orderDetail3);
            await dbContext.SaveChangesAsync();

            order.orderDetails = new List<OrderDetail> { orderDetail1, orderDetail2, orderDetail3 };
            order.user = user;
            await dbContext.SaveChangesAsync();

            var ordersService = new OrderService(dbContext, mapper);
            var ordersController = new OrdersController(ordersService, mapper);
            // Act
            var result = await ordersController.GetOrder(order.orderId);
            // Assert
            var ordersResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(ordersResult.Value as Order);
        }




    }
}
