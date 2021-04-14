using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.UnitTest.MockData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.CategoriesControllerTest.Tests
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
            var categoryToAdd = NewDatas.NewCategory();
            var categoriesService = new CategoryService(dbContext);
            var categoriesController = new CategoriesController(categoriesService);
            // Act
            var result = await categoriesController.Post(categoryToAdd);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(1, dbContext.Categories.Count());

        }
    }
}
