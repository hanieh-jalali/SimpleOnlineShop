using Application.Dto;
using Application.IService;
using SimpleOnlineStore.Domain.IRepository;
using SimpleOnlineStore.Domain.Models;
using Application.Helper;

namespace SimpleOnlineStore.Application.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddAsync(ProductDto productDto)
        {
            var product = productDto.ToModel();
            product.Validate();

            return await _productRepository.AddAsync(product);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var productDto = product.ToDto();
            productDto.PriceWithDiscount = product.Price - (product.Price * product.Discount / 100);

            return productDto;
        }

        public Task<bool> UpdateAsync(UpdateProductDto updateProductDto)
        {
            var product = updateProductDto.ToModel();

            return _productRepository.UpdateAsync(product);
        }
    }
}
