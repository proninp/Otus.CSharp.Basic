using HomeWork08;
using HomeWork08.Abstractions;
using HomeWork08.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<IEntityPrinter<Employee>, EmployeeConsolePrinter>();
services.AddTransient<IEmployeeManager, EmployeeManager>();
services.AddTransient<BinaryTree<Employee>>();
services.AddTransient<AppService>();

var serviceProvider = services.BuildServiceProvider();

var appService = serviceProvider.GetRequiredService<AppService>();
appService.Run();