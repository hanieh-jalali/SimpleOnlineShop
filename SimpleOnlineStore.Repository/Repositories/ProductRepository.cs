using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SimpleOnlineStore.Domain.IRepository;
using SimpleOnlineStore.Domain.Models;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(ApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _applicationDbContext = applicationDbContext;
            _memoryCache = memoryCache;
        }

        public async Task<Product> AddAsync(Product product)
        {
            if (_applicationDbContext.Products.Any(w => w.Title == product.Title))
                throw new Exception("Title already exists!");

            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();

            _memoryCache.Remove("Product");

            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            var cachedProduct = _memoryCache.Get("Product");
            if (cachedProduct is not null)
                return (Product)cachedProduct;

            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(w => w.Id == id);

            _memoryCache.Set("Product", product, TimeSpan.FromMinutes(2));

            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _applicationDbContext.Update(product);
            _applicationDbContext.SaveChanges();

            _memoryCache.Remove("Product");

            return true;
        }

        public Task<bool> CheckExist(int id)
        {
            var cachedProduct = _memoryCache.Get("Product");
            if (cachedProduct is not null)
                return Task.FromResult(true);

            if (_applicationDbContext.Products.Any(w => w.Id == id))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
