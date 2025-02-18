using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.Services.Interfaces;
public interface ICustomerService
{
    Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken);

    Task<IEnumerable<CustomerDto>> GetAll(CancellationToken cancellationToken);

    Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken);

    Task<int> UpdateAsync(Customer customer, CancellationToken cancellationToken);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}