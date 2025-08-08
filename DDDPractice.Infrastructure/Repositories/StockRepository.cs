using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Practice.DDDPractice.Infrastructure.Repositories;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;

    public StockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StockEntity>> GetAllAsync()
    {
        return await _context.Stock
            .ToListAsync();
    }

    public async Task<StockEntity> GetByProductIdAsync(Guid productId)
    {
        var stock = await _context.Stock
            .Include(s => s.Product)
            .FirstOrDefaultAsync(s => s.ProductId == productId);

        if (stock == null)
            throw new Exception("Stock not found.");

        return stock;
    }

    public async Task UpdateQuantityAsync(Guid productId, int newQuantity)
    {
        var stock = await _context.Stock.FindAsync(productId);
        if (stock == null)
            throw new Exception("Stock not found.");

        stock.Quantity = newQuantity;
        await _context.SaveChangesAsync();

    }

    public async Task AddAsync(StockEntity stock)
    {
        _context.Stock.Add(stock);
        await _context.SaveChangesAsync();
    }
}