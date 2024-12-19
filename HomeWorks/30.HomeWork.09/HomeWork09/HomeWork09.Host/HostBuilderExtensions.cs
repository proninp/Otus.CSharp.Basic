using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace HomeWork09.Host;
public static class HostBuilderExtensions
{
    public static IHostBuilder AddLogging(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .CreateLogger();
        return hostBuilder.UseSerilog(Log.Logger);
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
