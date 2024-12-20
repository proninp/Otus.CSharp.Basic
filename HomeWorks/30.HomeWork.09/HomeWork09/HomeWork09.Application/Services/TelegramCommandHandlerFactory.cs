using HomeWork09.Application.Abstract;
using HomeWork09.Application.Services.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork09.Application.Services;
public sealed class TelegramCommandHandlerFactory : ITelegramCommandHandlerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TelegramCommandHandlerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITelegramCommandHandler GetResponseHandler(string message)
    {
        return message switch
        {
            "/cat" => _serviceProvider.GetRequiredService<CatFactCommandHandler>(),
            _ => _serviceProvider.GetRequiredService<UnknownCommandHandler>()
        };
    }
}
