using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace HomeWork09.Application.Abstract;
public abstract class ReceiverServiceBase<TUpdateHandler> : IReceiverService
    where TUpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly TUpdateHandler _updateHandler;
    private readonly IBotInfoProvider _botInfoProvider;
    private readonly ILogger _logger;

    protected ReceiverServiceBase(
        ITelegramBotClient botClient,
        TUpdateHandler updateHandler,
        IBotInfoProvider botInfoProvider,
        ILogger logger)
    {
        _botClient = botClient;
        _updateHandler = updateHandler;
        _botInfoProvider = botInfoProvider;
        _logger = logger;
    }

    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions() { DropPendingUpdates = true, AllowedUpdates = [] };

        var me = await _botClient.GetMe(stoppingToken);
        _botInfoProvider.Info = $"Бот {me.Username} запущен, время: {DateTime.Now}";
        _logger.Information(_botInfoProvider.GetBotInfo());
        await _botClient.ReceiveAsync(_updateHandler, receiverOptions, stoppingToken);
    }
}