using Application.Dto;
using SimpleOnlineStore.Domain.Models;

namespace Application.IService
{
    public interface IProductService
    {
        public Task<Product> AddAsync(ProductDto product);
        public Task<bool> UpdateAsync(UpdateProductDto product);
        public Task<ProductDto> GetProductById(int id);
    }
}
