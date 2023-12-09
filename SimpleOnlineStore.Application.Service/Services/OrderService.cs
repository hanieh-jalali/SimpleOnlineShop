using Application.Dto;
using Application.Helper;
using Application.IService;
using SimpleOnlineStore.Domain.IRepository;
using SimpleOnlineStore.Domain.Models;

namespace SimpleOnlineStore.Application.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository
            , IProductRepository productRepository
            , IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<Order> AddAsync(OrderDto orderDto)
        {
            var productExist = _productRepository.CheckExist(orderDto.ProductId);
            var userExist = _userRepository.CheckExist(orderDto.BuyerId);

            if (!await productExist)
                throw new Exception("Product does not exist");
            if (!await userExist)
                throw new Exception("Buyer does not exist");

            var order = orderDto.ToModel();

            return await _orderRepository.AddAsync(order);
        }
    }
}
