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
    public class Put : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Put (SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Fact]
        public async Task Put_Success ()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();
            var user = NewDatas.NewUser();
            var product = NewDatas.NewProduct();
            var rating = NewDatas.NewRating();
            string commentToPut, commentAfterPut;
            commentToPut = commentAfterPut = "Comment Changed";
            int valueToPut, valueAfterPut;
            valueToPut = valueAfterPut = 5;
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
            var result = await ratingsController.PutRating(rating.ratingId, user.Id, product.productId, valueToPut, commentToPut);
            // Assert
            var ratingResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((ratingResult.Value as Rating).rateValue, valueAfterPut);
            Assert.Equal((ratingResult.Value as Rating).comment, commentAfterPut);

        }
    }
}
