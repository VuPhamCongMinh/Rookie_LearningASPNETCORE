using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Controllers;
using SimpleShop.API.Services;
using SimpleShop.Shared.Models;
using SimpleShop.UnitTest.MockData;
using System.Threading.Tasks;
using Xunit;

namespace SimpleShop.UnitTest.ProductsControllerTest.Tests
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
            var fileService = FileServiceMock.FilesService();
            var productToPut = NewDatas.NewProductPutRequest();
            var productBeforePut = NewDatas.NewProduct(); productBeforePut.productId = 10; //set productId in order to update
            var productAfterPut = NewDatas.ProductAfterPut();
            var category = NewDatas.NewCategory();

            await dbContext.Categories.AddAsync(category);
            await dbContext.Products.AddAsync(productBeforePut);
            await dbContext.SaveChangesAsync(); productToPut.categoryId = category.categoryId;
            var productsService = new ProductService(dbContext, fileService, mapper);
            var productsController = new ProductsController(productsService, fileService);
            // Act
            var result = await productsController.PutProduct(10, productToPut);
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(productBeforePut.productName, productAfterPut.productName);
            Assert.Equal(productBeforePut.productPrice, productAfterPut.productPrice);
            Assert.Equal(productBeforePut.productDescription, productAfterPut.productDescription);
            Assert.Equal(productBeforePut.Images.Count, productAfterPut.Images.Count);
            Assert.Equal(productBeforePut.Category, category);

        }
    }
}
