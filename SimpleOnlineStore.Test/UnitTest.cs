using Application.Dto;
using Application.IService;
using Moq;
using SimpleOnlineStore.Application.Core.Services;
using SimpleOnlineStore.Domain.IRepository;
using SimpleOnlineStore.Domain.Models;

namespace SimpleOnlineStore.Test
{
    public class ProductServiceUnitTest
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductServiceUnitTest()
        {
            var _productRepositoryMocked = new Mock<IProductRepository>();
            //_productRepository.Setup
            _productService = new ProductService(_productRepositoryMocked.Object);

            _productRepositoryMocked.Setup(s => s.GetProductById(It.IsAny<int>()))
                .Returns(() => 
            {
                return Task.FromResult(new Product() 
                {
                    Discount = 10,
                    Id = 1,
                    InventoryCount = 1,
                    Price = 100,
                    Title = "Product"
                });
            });
        }

        [Fact]
        public void AddProduct_Product_TitleLenghtException()
        {
            //Arrange
            var productDto = new ProductDto()
            {
                Discount = 1,
                InventoryCount = 1,
                Price = 1,
                Title = "This title is more than 40 characters so I expect an exception to be raised."
            };

            //Act
            var result = _productService.AddAsync(productDto);

            //Assert
            var exception = Assert.ThrowsAny<Exception>(() => result.Result);
            Assert.Equal("One or more errors occurred. (Title must be less than 40 char)", exception.Message);
        }

        [Fact]
        public void GetProductById_Id_Price()
        {
            //Arrange
            var productId = 1;

            //Act
            var result = _productService.GetProductById(productId).Result;

            //Assert
            Assert.Equal(90, result.PriceWithDiscount);
        }
    }
}