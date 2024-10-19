using HomeWork05.src;
using HomeWork05.src.Abstractions;
using HomeWork05.src.Utils;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddSingleton<Application>()
    .AddSingleton<IPrintable, ConsolePrinter>()
    .AddTransient<Quadcopter>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();
app.Run();