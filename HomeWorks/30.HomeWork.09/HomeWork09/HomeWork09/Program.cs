using CompositionRoot;
using HomeWork09.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var hostBuilder = Host.CreateDefaultBuilder(args)
    .AddLogging(configuration)
    .AddGlobalExceptionHandling();

hostBuilder.ConfigureServices(services => services.AddApplication(configuration));

using var host = hostBuilder.Build();

var app = host.Services.GetRequiredService<AppService>();
app.Run();