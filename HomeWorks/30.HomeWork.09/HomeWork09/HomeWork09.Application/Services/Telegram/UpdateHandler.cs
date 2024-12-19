using HomeWork09.Application.Abstract;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HomeWork09.Application.Services.Telegram;
public class UpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUpdateEventProvider _eventProvider;
    private readonly ILogger _logger;

    public UpdateHandler(ITelegramBotClient botClient, IUpdateEventProvider eventProvider, ILogger logger)
    {
        _botClient = botClient;
        _eventProvider = eventProvider;
        _logger = logger;
    }

    public async Task HandleErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        HandleErrorSource source,
        CancellationToken cancellationToken)
    {
        _logger.Information("HandleError: {Exception}", exception);

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
        _logger.Information("Receive message type: {MessageType}", message.Type);

        if (message.Text is not { } messageText)
            return;

        _eventProvider.RaiseUpdateStarted(message.Text);

        var echo = $"Сообщение успешно принято: '{messageText}'";

        var sentMessage = await _botClient.SendMessage(message.Chat, echo, parseMode: ParseMode.Html, replyMarkup: new ReplyKeyboardRemove());

        _logger.Information($"The message was sent with id: {sentMessage.Id}");

        _eventProvider.RaiseUpdateCompleted(message.Text);
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        _logger.Information("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }
}
