using Application.Dto;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace SimpleOnlineStore.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _OrderService;

    public OrderController(ILogger<OrderController> logger, IOrderService OrderService)
    {
        _logger = logger;
        _OrderService = OrderService;
    }

    [HttpPost]
    [Route("CreateOrder")]
    public IActionResult CreateOrder([FromBody] OrderDto orderDto)
    {
        try
        {
            _OrderService.AddAsync(orderDto).Wait();
            return Ok("Order added succussfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}