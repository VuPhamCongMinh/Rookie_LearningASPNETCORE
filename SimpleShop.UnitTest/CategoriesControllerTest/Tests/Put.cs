using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.API;
using SimpleShop.API.Services;
using SimpleShop.UnitTest.MockData;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.CategoriesControllerTest.Tests
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
            var category = NewDatas.NewCategory();
            var categoryPutRequest = NewDatas.CategoryPutRequest();
            var categoryAfterPut = NewDatas.CategoryAfterPut();

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            var categoriesService = new CategoryService(dbContext);
            var categoriesController = new CategoriesController(categoriesService);
            // Act
            var result = await categoriesController.Put(category.categoryId, categoryPutRequest);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(category.categoryName, categoryAfterPut.categoryName);

        }
    }
}
