using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.Services.Interfaces;
public interface IOrderService
{
    Task<OrderDto?> GetById(int id, CancellationToken cancellationToken);

    Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken);

    Task<Order> AddAsync(Order order, CancellationToken cancellationToken);

    Task<int> UpdateAsync(Order order, CancellationToken cancellationToken);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}