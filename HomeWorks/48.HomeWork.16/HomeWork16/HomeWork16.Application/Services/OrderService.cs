using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using HomeWork16.Domain.Interfaces.Repositories;
using HomeWork16.Domain.Models;
using LinqToDB;

namespace HomeWork16.Application.Services;
public class OrderService : IOrderService
{
    private readonly IRepository<Order> _repository;

    public OrderService(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<OrderDto?> GetById(int id, CancellationToken cancellationToken) =>
        await _repository.GetByIdAsync(
            id, 
            o => o.ToDto(),
            query => query
                .LoadWith(o => o.Customer)
                .LoadWith(o => o.Product),
            cancellationToken);

    public async Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken) =>
        await _repository.GetAsync(
            o => o.ToDto(),
            query => query
                .LoadWith(o => o.Customer)
                .LoadWith(o => o.Product),
            cancellationToken: cancellationToken);

    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken) =>
        await _repository.AddAsync(order, cancellationToken);

    public async Task<int> UpdateAsync(Order order, CancellationToken cancellationToken) =>
        await _repository.UpdateAsync(order, cancellationToken);

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(id, cancellationToken);
}
