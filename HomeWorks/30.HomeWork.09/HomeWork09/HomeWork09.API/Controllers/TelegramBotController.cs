using HomeWork09.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork09.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TelegramBotController : ControllerBase
{
    private readonly Serilog.ILogger _logger;

    public TelegramBotController(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "StopBot")]
    public async Task<ActionResult<BotCommandResponse>> PostContact([FromBody] BotCommandRequest request)
    {
        _logger.Information($"Полчен запрос: '{request}'");

        

        return Ok();
    }
}
