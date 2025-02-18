using HomeWork16.Application.DTOs.ViewModels;
using HomeWork16.Domain.Models;

namespace HomeWork16.Application.Services.Interfaces;
public interface IProductService
{
    Task<ProductDto?> GetById(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken);

    Task<Product> AddAsync(Product product, CancellationToken cancellationToken);

    Task<int> UpdateAsync(Product product, CancellationToken cancellationToken);

    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
}