using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.UnitTest.MockData;
using SimpleShop.UnitTest.ProductsControllerTest;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.CategoriesControllerTest.Tests
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
            var category = NewDatas.NewCategory();

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            var categoriesService = new CategoryService(dbContext);
            var categoriesController = new CategoriesController(categoriesService);
            // Act
            var result =await categoriesController.GetCategories();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetSingle_Success (int id)
        {
            // Arrange
            var dbContext = _fixture.Context;
            var category1 = NewDatas.NewCategory();
            var category2 = NewDatas.NewCategory();

            await dbContext.Categories.AddRangeAsync(category1, category2);
            dbContext.SaveChanges();

            var categoriesService = new CategoryService(dbContext);
            var categoriesController = new CategoriesController(categoriesService);
            // Act
            var result = await categoriesController.GetCategory(id);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }




    }
}
