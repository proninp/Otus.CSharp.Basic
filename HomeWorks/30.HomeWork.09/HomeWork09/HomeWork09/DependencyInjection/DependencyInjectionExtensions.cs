using HomeWork09.Options;
using HomeWork09.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using Telegram.Bot;

namespace CompositionRoot;

public static class DependencyInjectionExtensions
{
    public static IHostBuilder AddLogging(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .CreateLogger();
        return hostBuilder.UseSerilog(Log.Logger);
    }

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)))
            .AddScoped<AppService>();

            services.AddHttpClient("telegram_bot_client").RemoveAllLoggers()
            .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
            {
                AppSettings botConfiguration = sp.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value;
                TelegramBotClientOptions options = new(botConfiguration.BotToken);
                return new TelegramBotClient(options, httpClient);
            });

        return services;
    }

    public static IHostBuilder AddGlobalExceptionHandling(this IHostBuilder hostBuilder)
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
        {
            var exception = eventArgs.ExceptionObject as Exception;
            Log.Fatal(exception, "An unhandled exception was caught in the AppDomain");
            Environment.Exit(1);
        };

        TaskScheduler.UnobservedTaskException += (sender, eventArgs) =>
        {
            Log.Fatal(eventArgs.Exception, "An UnobservedTaskException was intercepted");
            eventArgs.SetObserved();
        };
        return hostBuilder;
    }
}
