using HomeWork16.Application.Services;
using HomeWork16.Application.Services.Interfaces;
using HomeWork16.Domain.Interfaces.Repositories;
using HomeWork16.Domain.Options;
using HomeWork16.Infrastructure.Data;
using HomeWork16.Infrastructure.Repositories;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLinqToDBContext<DatabaseContext>((provider, options) =>
{
    var appSettings = provider.GetRequiredService<IOptionsSnapshot<AppSettings>>().Value;
    return options.UsePostgreSQL(appSettings.OtusDbConnectionString);
});
    
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
