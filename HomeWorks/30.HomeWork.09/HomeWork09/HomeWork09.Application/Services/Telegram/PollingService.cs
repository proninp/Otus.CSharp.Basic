using HomeWork09.Application.Abstract;
using Serilog;

namespace HomeWork09.Application.Services.Telegram;
public sealed class PollingService : IPollingService
{
    private readonly IReceiverService _receiver;
    private readonly IUpdateEventProvider _eventProvider;
    private readonly IBotInfoProvider _botInfoProvider;
    private readonly ILogger _logger;

    public PollingService(
        IReceiverService receiver,
        IUpdateEventProvider eventProvider,
        IBotInfoProvider botInfoProvider,
        ILogger logger)
    {
        _receiver = receiver;
        _eventProvider = eventProvider;
        _botInfoProvider = botInfoProvider;
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
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                _logger.Error("Polling canceled with canceled exception");
                _botInfoProvider.Reset();
            }
            catch (Exception ex)
            {
                _logger.Error("Polling failed with exception: {Exception}", ex);
                _botInfoProvider.Reset();
                // Cooldown if something goes wrong
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
            finally
            {
                _eventProvider.OnHandleUpdateStarted -= messageHandlerStart;
                _eventProvider.OnHandleUpdateCompleted -= messageHandlerComplete;
            }
        }
    }
}