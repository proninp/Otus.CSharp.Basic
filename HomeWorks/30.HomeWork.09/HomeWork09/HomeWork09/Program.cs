using CompositionRoot;
using HomeWork09.Abstract;
using HomeWork09.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .AddLogging(configuration)
    .AddGlobalExceptionHandling();

hostBuilder.ConfigureServices(services => services.AddApplication(configuration));

using var host = hostBuilder.Build();

using var scope = host.Services.CreateScope();
var tokenProvider = scope.ServiceProvider.GetRequiredService<ICancellationTokenProvider>();

var app = scope.ServiceProvider.GetRequiredService<AppService>();
var appTask = Task.Run(() => app.Run(default));

await host.RunAsync(tokenProvider.Token);
await appTask;