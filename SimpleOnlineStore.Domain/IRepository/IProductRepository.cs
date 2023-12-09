using SimpleOnlineStore.Domain.Models;

namespace SimpleOnlineStore.Domain.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> AddAsync(Product product);
        public Task<bool> UpdateAsync(Product product);
        public Task<Product> GetProductById(int id);
        public Task<bool> CheckExist(int id);
    }
}
