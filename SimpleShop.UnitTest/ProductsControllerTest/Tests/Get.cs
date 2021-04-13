using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.UnitTest.MockData;
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
            var product1 = NewDatas.NewProduct();
            
            dbContext.Products.Add(product1);
            dbContext.SaveChanges();

            var productsService = new ProductService(dbContext, fileService, mapper);
            var productsController = new ProductsController(productsService);
            // Act
            var result = productsController.GetProducts();
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
            var mapper = MapperMock.Get();
            var fileService = FileServiceMock.FilesService();
            var product1 = NewDatas.NewProduct();
            var product2 = NewDatas.NewProduct();

            await dbContext.Products.AddRangeAsync(product1,product2);
            dbContext.SaveChanges();

            var productsService = new ProductService(dbContext, fileService, mapper);
            var productsController = new ProductsController(productsService);
            // Act
            var result = await productsController.GetProduct(id);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

       


    }
}
