using HomeWork09.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace HomeWork09.Application.Injection;
public static class TelegramInjector
{
    public static IServiceCollection AddTelegram(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("telegram_bot_client").RemoveAllLoggers()
            .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
            {
                AppSettings botConfiguration = sp.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value;
                TelegramBotClientOptions options = new(botConfiguration.BotToken);
                return new TelegramBotClient(options, httpClient);
            });
        return services;
    }
}
