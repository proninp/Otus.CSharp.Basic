using HomeWork03.Abstractions;
using HomeWork03.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddSingleton<AppService>()
    .AddSingleton<ConsoleHelper>()
    .AddSingleton<ICoefficientable, CoefficientProvider>()
    .AddSingleton<IEquationSolver, QuadEquationSolver>()
    .AddSingleton<IEquationFormatter, QuadEquationFormatter>()
    .AddSingleton<IEquationValidator, QuadEquationValidator>()
    .AddSingleton<IExceptionHandler, ExceptionHandler>()
    .AddSingleton<OutputManager>()
    .AddSingleton<IEquationPrinter, QuadEquationPrinter>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var appService = serviceProvider.GetRequiredService<AppService>();
appService.Run();