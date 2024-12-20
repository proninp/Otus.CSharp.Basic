using HomeWork09.Application.Abstract;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace HomeWork09.Application.Services.Telegram;
public sealed class UpdateHandler : IUpdateHandler
{
    private readonly IUpdateEventProvider _eventProvider;
    private readonly IBotInfoProvider _botInfoProvider;
    private readonly ITelegramCommandHandlerFactory _handlerFactory;
    private readonly ILogger _logger;

    public UpdateHandler(
        IUpdateEventProvider eventProvider,
        IBotInfoProvider infoProvider,
        ITelegramCommandHandlerFactory handlerFactory,
        ILogger logger)
    {
        _eventProvider = eventProvider;
        _botInfoProvider = infoProvider;
        _handlerFactory = handlerFactory;
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
        _botInfoProvider.LastMessageInfo = $"Последнее принятое сообщение в {DateTime.Now}: '{message.Text}'";

        var commandHandler = _handlerFactory.GetResponseHandler(message.Text);
        var sentMessage = await commandHandler.Handle(message);

        if (sentMessage is not null)
            _logger.Information($"The message was sent with id: {sentMessage.Id}");

        _eventProvider.RaiseUpdateCompleted(message.Text);
    }

    private Task UnknownUpdateHandlerAsync(Update update)
    {
        _logger.Information("Unknown update type: {UpdateType}", update.Type);
        return Task.CompletedTask;
    }
}
