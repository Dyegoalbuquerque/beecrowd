using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly SalesDbContext _context;

    public ProductRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Set<Product>().ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
        await _context.SaveChangesAsync();
    }
}