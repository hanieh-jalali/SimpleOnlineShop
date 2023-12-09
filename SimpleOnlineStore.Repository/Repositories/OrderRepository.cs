using Microsoft.Extensions.Caching.Memory;
using SimpleOnlineStore.Domain.IRepository;
using SimpleOnlineStore.Domain.Models;

namespace Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;

        public OrderRepository(ApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _applicationDbContext = applicationDbContext;
            _memoryCache = memoryCache;
        }

        public async Task<Order> AddAsync(Order order)
        {
            _applicationDbContext.Entry(order.Buyer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            _applicationDbContext.Entry(order.Product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            _applicationDbContext.Orders.Add(order);
            _applicationDbContext.SaveChanges();

            _memoryCache.Remove("Order");

            return order;
        }
    }
}
