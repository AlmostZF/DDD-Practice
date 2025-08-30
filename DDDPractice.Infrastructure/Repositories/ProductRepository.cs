using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DDD_Practice.DDDPractice.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductEntity> GetByIdAsync(Guid id)
    {
        var product = await _context.Product
            .Include(p => p.Seller)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (product == null)
            throw new Exception("Product not found.");
        
        return product;

    }

    public async Task UpdateAsync(ProductEntity product)
    {
        var existingProduct = await _context.Product.FindAsync(product.Id);
        if (existingProduct == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
            throw new Exception("Product not found.");
        
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(ProductEntity product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Product
            .Include(p=> p.Seller)
            .ToListAsync();
    }
}