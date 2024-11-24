using HomeWork08.Abstractions;
using HomeWork08.Models;
using HomeWork08.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<IPrinter, ConsolePrinterBase>();
services.AddTransient<IEntityPrinter<Employee>, EmployeeConsolePrinter>();
services.AddTransient<IInputService, InputService>();
services.AddTransient<IEmployeeManager, EmployeeManager>();
services.AddTransient<BinaryTree<Employee>>();
services.AddTransient<MenuService>();
services.AddTransient<AppService>();

var serviceProvider = services.BuildServiceProvider();

var appService = serviceProvider.GetRequiredService<AppService>();
appService.Run();