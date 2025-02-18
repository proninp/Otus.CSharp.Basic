using HomeWork16.Application.DTOs.Commands.Create;
using HomeWork16.Application.DTOs.Commands.Update;
using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork16.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _customerService.GetAll(cancellationToken);
        if (result is null || result.Count() == 0)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _customerService.GetById(id, cancellationToken);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> PutCustomer([FromBody] UpdateCustomerDto body, CancellationToken cancellationToken)
    {
        await _customerService.UpdateAsync(body.ToModel(), cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> PostCustomer([FromBody] CreateCustomerDto body, CancellationToken cancellationToken)
    {
        return (await _customerService.AddAsync(body.ToModel(), cancellationToken)).ToDto();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _customerService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}