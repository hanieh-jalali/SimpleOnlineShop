using Application.Dto;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace SimpleOnlineStore.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPost]
    [Route("CreateProduct")]
    public IActionResult CreateProduct([FromBody] ProductDto product)
    {
        try
        {
            _productService.AddAsync(product).Wait();
            return Ok("Product added succussfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetProductById")]
    public IActionResult GetProductById([FromQuery] int productId)
    {
        try
        {
            var product = _productService.GetProductById(productId).Result;

            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateProductCommand")]
    public IActionResult UpdateProduct([FromBody] UpdateProductDto updateProductDto)
    {
        try
        {
            var result = _productService.UpdateAsync(updateProductDto).Result;
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}