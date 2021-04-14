using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.UnitTest.MockData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.RatingsControllerTest.Tests
{
    public class Post : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Post (SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Theory]
        [InlineData(1,"Ok")]
        [InlineData(2,"No Ok")]
        public async Task Post_Success (int rateValue,string comment)
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();
            var user = NewDatas.NewUser();
            var product = NewDatas.NewProduct();
            var rating = NewDatas.NewRating();
            rating.User = user;
            rating.Product = product;

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            dbContext.Ratings.Add(rating);
            await dbContext.SaveChangesAsync();

            var ratingsService = new RatingService(dbContext);
            var ratingsController = new RatingsController(ratingsService, mapper);
            // Act
            var result = await ratingsController.PostRating(user.Id,product.productId,rateValue,comment);
            // Assert
            var ratingResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.NotNull(ratingResult.Value as Rating);

        }
    }
}
