using HomeWork09.Abstract;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HomeWork09.Services.Telegram;
public class UpdateHandler(
    ITelegramBotClient bot,
    IUpdateEventProvider eventProvider,
    ILogger logger) : IUpdateHandler
{
    public async Task HandleErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        HandleErrorSource source,
        CancellationToken cancellationToken)
    {
        logger.Information("HandleError: {Exception}", exception);

        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await (update switch
        {
            { Message: { } message } => OnMessage(message),
            _ => UnknownUpdateHandlerAsync(update)
        });
    }

    private async Task OnMessage(Message message)
    {
        logger.Information("Receive message type: {MessageType}", message.Type);
        
        if (message.Text is not { } messageText)
            return;

        eventProvider.RaiseUpdateStarted(message.Text);

        var echo = $"Сообщение успешно принято: '{messageText}'";

        var sentMessage = await bot.SendMessage(message.Chat, echo, parseMode: ParseMode.Html, replyMarkup: new ReplyKeyboardRemove());

        logger.Information($"The message was sent with id: {sentMessage.Id}");
        
        eventProvider.RaiseUpdateCompleted(message.Text);
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        logger.Information("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }
}
