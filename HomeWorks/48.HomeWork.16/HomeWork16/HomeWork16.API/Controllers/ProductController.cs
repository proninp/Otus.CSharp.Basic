using HomeWork16.Application.DTOs.Commands.Create;
using HomeWork16.Application.DTOs.Commands.Update;
using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork16.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _productService.GetAll(cancellationToken);
        if (result is null || result.Count() == 0)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetById(id, cancellationToken);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> PutProduct([FromBody] UpdateProductDto body, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(body.ToModel(), cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> PostProduct([FromBody] CreateProductDto body, CancellationToken cancellationToken)
    {
        return (await _productService.AddAsync(body.ToModel(), cancellationToken)).ToDto();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}