using Application.Dto;
using SimpleOnlineStore.Domain.Models;
using System.Text.Json;

namespace Application.Helper
{
    public static class Mapper
    {
        public static ProductDto ToDto(this Product product)
        {
            if (product is null) return null!;

            var productDto = new ProductDto()
            {
                Price = product.Price,
                Discount = product.Discount,
                InventoryCount = product.InventoryCount,
                Title = product.Title
            };

            return productDto;
        }

        public static UserDto ToDto(this User user)
        {
            if (user is null) return null!;

            var userDto = new UserDto()
            {
                Id = user.Id,
                Name = user.Name
            };

            userDto.Orders = JsonSerializer.Deserialize<List<OrderDto>>(JsonSerializer.Serialize(user.Orders));

            return userDto;
        }

        public static Product ToModel(this ProductDto productDto)
        {
            if (productDto is null) return null!;

            var product = new Product()
            {
                Price = productDto.Price,
                Discount = productDto.Discount,
                InventoryCount = productDto.InventoryCount,
                Title = productDto.Title
            };

            return product;
        }

        public static Product ToModel(this UpdateProductDto updateProductDto)
        {
            if (updateProductDto is null) return null!;

            var product = new Product()
            {
                Id = updateProductDto.Id,
                Price = updateProductDto.Price,
                Discount = updateProductDto.Discount,
                InventoryCount = updateProductDto.InventoryCount,
                Title = updateProductDto.Title
            };

            return product;
        }

        public static Order ToModel(this OrderDto orderDto)
        {
            if (orderDto is null) return null!;

            var order = new Order()
            {
                CreationDate = DateTime.Now,
                Buyer = new User() { Id = orderDto.BuyerId },
                Product = new Product() { Id = orderDto.ProductId }
            };

            return order;
        }
    }
}
