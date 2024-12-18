using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace HomeWork09.Abstract;
public abstract class ReceiverServiceBase<TUpdateHandler>(
    ITelegramBotClient botClient,
    TUpdateHandler updateHandler,
    IBotInfoProvider botInfoProvider,
    ILogger logger)
    : IReceiverService where TUpdateHandler : IUpdateHandler
{
    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions() { DropPendingUpdates = true, AllowedUpdates = [] };

        var me = await botClient.GetMe(stoppingToken);
        var botName = me.Username ?? "My Awesome Bot";
        logger.Information($"Start receiving updates for {botName}");

        botInfoProvider.BotInfo = $"Бот {me.Username} работает, время: {DateTime.Now}";

        await botClient.ReceiveAsync(updateHandler, receiverOptions, stoppingToken);
    }
}
