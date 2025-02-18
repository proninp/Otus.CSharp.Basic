using HomeWork16.Application.DTOs.Commands.Create;
using HomeWork16.Application.DTOs.Commands.Update;
using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAll(cancellationToken);
        if (result is null || result.Count() == 0)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetById(id, cancellationToken);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> PutOrder([FromBody] UpdateOrderDto body, CancellationToken cancellationToken)
    {
        await _orderService.UpdateAsync(body.ToModel(), cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> PostOrder([FromBody] CreateOrderDto body, CancellationToken cancellationToken)
    {
        return (await _orderService.AddAsync(body.ToModel(), cancellationToken)).ToDto();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _orderService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}