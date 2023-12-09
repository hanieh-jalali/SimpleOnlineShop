using Application.Dto;
using SimpleOnlineStore.Domain.Models;

namespace Application.IService
{
    public interface IOrderService
    {
        public Task<Order> AddAsync(OrderDto order);
    }
}
