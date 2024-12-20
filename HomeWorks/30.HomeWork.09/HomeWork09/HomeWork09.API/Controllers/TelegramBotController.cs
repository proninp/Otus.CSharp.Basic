using HomeWork09.Application.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork09.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TelegramBotController : ControllerBase
{
    private readonly IBotManager _botManager;

    public TelegramBotController(IBotManager botManager)
    {
        _botManager = botManager;
    }

    [HttpGet("info")]
    public IActionResult Info()
    {
        return Ok(_botManager.Info());
    }

    [HttpPost("stop")]
    public IActionResult StopBot()
    {
        _botManager.Stop();
        return Ok("Бот остановлен");
    }
}