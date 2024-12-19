using HomeWork09.Application.Abstract;
using Serilog;

namespace HomeWork09.Application.Services.Telegram;
public class PollingService : IPollingService
{
    private readonly IReceiverService _receiver;
    private readonly IUpdateEventProvider _eventProvider;
    private readonly ILogger _logger;

    public PollingService(IReceiverService receiver, IUpdateEventProvider eventProvider, ILogger logger)
    {
        _receiver = receiver;
        _eventProvider = eventProvider;
        _logger = logger;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        Action<string> messageHandlerStart = message =>
            _logger.Information($"В OnHandleUpdateStarted началась обработка ообщения: '{message}'");
        Action<string> messageHandlerComplete = message =>
            _logger.Information($"В OnHandleUpdateCompleted закончилась обработка ообщения: '{message}'");

        _eventProvider.OnHandleUpdateStarted += messageHandlerStart;
        _eventProvider.OnHandleUpdateCompleted += messageHandlerComplete;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await _receiver.ReceiveAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.Error("Polling failed with exception: {Exception}", ex);
                // Cooldown if something goes wrong
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
            finally
            {
                _eventProvider.OnHandleUpdateStarted -= messageHandlerStart;
                _eventProvider.OnHandleUpdateCompleted -= messageHandlerComplete;
            }
        }
    }
}