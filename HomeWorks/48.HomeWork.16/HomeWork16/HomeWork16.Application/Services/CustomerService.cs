using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using HomeWork16.Domain.Interfaces.Repositories;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.Services;
public sealed class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;

    public CustomerService(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken) =>
        await _repository.GetByIdAsync(
            id, c => c.ToDto(),
            cancellationToken: cancellationToken);

    public async Task<IEnumerable<CustomerDto>> GetAll(CancellationToken cancellationToken) =>
        await _repository.GetAsync(
            c => c.ToDto(),
            cancellationToken: cancellationToken);

    public async Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken) =>
        await _repository.AddAsync(customer, cancellationToken);

    public async Task<int> UpdateAsync(Customer customer, CancellationToken cancellationToken) =>
        await _repository.UpdateAsync(customer, cancellationToken);

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(id, cancellationToken);
}