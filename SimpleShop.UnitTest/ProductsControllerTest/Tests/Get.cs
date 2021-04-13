using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.ProductsControllerTest.Tests
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
        public void GetAll_Success ()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();
            var fileService = FileServiceMock.FilesService();

            var productsService = new ProductService(dbContext, fileService, mapper);
            var productsController = new ProductsController(productsService);
            // Act
            var result = productsController.GetProducts();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}
