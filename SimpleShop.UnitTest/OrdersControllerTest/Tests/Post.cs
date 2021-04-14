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
    public class Post : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Post (SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Fact]
        public async Task Post_Success ()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();

            var user = NewDatas.NewUser();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product1 = NewDatas.NewProduct();
            await dbContext.Products.AddAsync(product1);
            await dbContext.SaveChangesAsync();

            var orderCreateRequest = NewDatas.NewOrderDetailRequest();
            orderCreateRequest.productId = product1.productId;

            var ordersService = new OrderService(dbContext, mapper);
            var ordersController = new OrdersController(ordersService, mapper);

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
            Assert.NotNull(ordersResult.Value as Order);
        }
    }
}
