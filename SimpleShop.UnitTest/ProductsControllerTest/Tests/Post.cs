using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.UnitTest.MockData;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.ProductsControllerTest.Tests
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
            var fileService = FileServiceMock.FilesService();
            var productToPost = NewDatas.NewProductPostRequest();

            var productsService = new ProductService(dbContext, fileService, mapper);
            var productsController = new ProductsController(productsService,fileService);
            // Act
            var result = await productsController.PostProduct(productToPost);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);

        }
    }
}
