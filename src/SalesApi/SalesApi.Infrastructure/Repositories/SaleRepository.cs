using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Infrastructure.Persistence;

namespace SalesApi.Infrastructure.Repositories;
public class SaleRepository : ISaleRepository
{
    private readonly SalesDbContext _context;

    public SaleRepository(SalesDbContext context)
    {
        _context = context;
    }

    public async Task<Sale> GetByIdAsync(Guid id)
    {
        return await _context.Set<Sale>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
        return await _context.Set<Sale>().ToListAsync();
    }

    public async Task AddAsync(Sale sale)
    {
        await _context.Set<Sale>().AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sale sale)
    {
       var exists = await  _context.Set<Sale>().AnyAsync(s => s.Id == sale.Id);
        if (exists)
        {
             _context.Set<Sale>().Update(sale);
            await _context.SaveChangesAsync();
        }
    }
}