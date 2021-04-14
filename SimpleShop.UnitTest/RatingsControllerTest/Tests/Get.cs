using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.UnitTest.MockData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.RatingsControllerTest.Tests
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
            var result = await ratingsController.GetRatings();
            // Assert
            var ratingResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotEmpty(ratingResult.Value as IEnumerable<Rating>);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetSingle_Success (int id)
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();
            var user1 = NewDatas.NewUser();
            var user2 = NewDatas.NewUser();
            var product = NewDatas.NewProduct();
            var rating = NewDatas.NewRating();
            rating.User = user1;
            rating.Product = product;
            var rating1 = NewDatas.NewRating();
            rating1.User = user2;
            rating1.Product = product;

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            dbContext.Users.AddRange(user1, user2);
            await dbContext.SaveChangesAsync();
            dbContext.Ratings.AddRange(rating, rating1);
            await dbContext.SaveChangesAsync();

            var ratingsService = new RatingService(dbContext);
            var ratingsController = new RatingsController(ratingsService, mapper);
            // Act
            var result = await ratingsController.GetRatingByProductId(id);
            // Assert
            var ratingResult =  Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(ratingResult.Value);
        }




    }
}
