using SalesApi.Domain.Entities;

namespace SalesApi.Domain.Repositories;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
}