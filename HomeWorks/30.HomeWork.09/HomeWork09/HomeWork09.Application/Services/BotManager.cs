using HomeWork09.Application.Abstract;
using Serilog;

namespace HomeWork09.Application.Services;
public sealed class BotManager : IBotManager
{
    private readonly ICancellationTokenProvider _tokenProvider;
    private readonly IBotInfoProvider _infoProvider;
    private readonly ILogger _logger;

    public BotManager(ICancellationTokenProvider tokenProvider, IBotInfoProvider infoProvider, ILogger logger)
    {
        _tokenProvider = tokenProvider;
        _infoProvider = infoProvider;
        _logger = logger;
    }

    public string Info()
    {
        _logger.Information($"{DateTime.Now}: Команда получения информации о боте");
        return _infoProvider.GetBotInfo();
    }

    public void Stop()
    {
        _logger.Information($"{DateTime.Now}: Команда остановки бота");
        _tokenProvider.Cancel();
        _infoProvider.Reset();
    }
}
