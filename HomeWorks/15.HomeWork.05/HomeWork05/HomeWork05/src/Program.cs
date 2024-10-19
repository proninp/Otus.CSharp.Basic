using HomeWork05.src;
using HomeWork05.src.Abstractions;
using HomeWork05.src.Utils;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddSingleton<ApplicationService>()
    .AddSingleton<IPrinter, ConsolePrinter>()
    .AddTransient<Quadcopter>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<ApplicationService>();
app.Run();