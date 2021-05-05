using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.UnitTest.MockData;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.OrdersControllerTest.Tests
{
    public class Put : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Put (SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Put_Success (int quantity)
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();

            var fileService = FileServiceMock.FilesService();

            var user = NewDatas.NewUser();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product1 = NewDatas.NewProduct();
            await dbContext.Products.AddRangeAsync(product1);
            await dbContext.SaveChangesAsync();

            #region create intial order data
            var order = NewDatas.NewOrder();
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            var orderDetail1 = NewDatas.NewOrderDetail();
            orderDetail1.productId = product1.productId;
            orderDetail1.orderId = order.orderId;

            int initialQuantity = orderDetail1.quantity;

            await dbContext.OrderDetails.AddRangeAsync(orderDetail1);
            await dbContext.SaveChangesAsync();

            order.orderDetails = new List<OrderDetail> { orderDetail1 };
            order.user = user;
            await dbContext.SaveChangesAsync();
            #endregion

            var orderCreateRequest = NewDatas.NewOrderDetailRequest();
            orderCreateRequest.productId = product1.productId;
            orderCreateRequest.quantity = quantity;

            int afterPostQuantity = quantity;

            var ordersService = new OrderService(dbContext, mapper);
            var ordersController = new OrdersController(ordersService, mapper,fileService);

            #region set controller user
            ordersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(CultureInfo.InvariantCulture))
                    }, "Bearer")
                    )
                }
            };
            #endregion

            // Act
            var result = await ordersController.PostOrder(orderCreateRequest);
            // Assert
            var ordersResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var productInOrderResult = (ordersResult.Value as Order).orderDetails.First(x => x.productId == product1.productId);
            Assert.Equal(productInOrderResult.quantity, initialQuantity + afterPostQuantity);

        }
    }
}
