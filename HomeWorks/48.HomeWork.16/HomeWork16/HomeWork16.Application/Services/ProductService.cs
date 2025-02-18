using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Application.Services.Interfaces;
using HomeWork16.Domain.Interfaces.Repositories;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.Services;
public sealed class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto?> GetById(int id, CancellationToken cancellationToken) =>
        await _repository.GetByIdAsync(
            id, p => p.ToDto(), cancellationToken: cancellationToken);

    public async Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken) =>
        await _repository.GetAsync(p => p.ToDto(), cancellationToken: cancellationToken);

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken) =>
        await _repository.AddAsync(product, cancellationToken);

    public async Task<int> UpdateAsync(Product product, CancellationToken cancellationToken) =>
        await _repository.UpdateAsync(product, cancellationToken);

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken) =>
        await _repository.DeleteAsync(id, cancellationToken);
}
