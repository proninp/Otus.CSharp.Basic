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
        var botInfo = me.Username ?? "My Awesome Bot";
        _botInfoProvider.BotInfo = botInfo;
        _logger.Information($"Бот {botInfo} работает, время: {DateTime.Now}");

        await _botClient.ReceiveAsync(_updateHandler, receiverOptions, stoppingToken);
    }
}