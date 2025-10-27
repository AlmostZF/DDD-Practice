using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<ProductEntity>> FilterAsync(ProductFilter productFilter)
    {

        var query = ApplyFilters(productFilter);
        return await query
            .Include(p=>p.Seller)
            .Skip((productFilter.PageNumber - 1) * productFilter.MaxItensPerPage)
            .Take(productFilter.MaxItensPerPage)
            .ToListAsync();
    }

    public async Task<int> CountAsync(ProductFilter productFilter)
    {
        var query = ApplyFilters(productFilter);
        return await query.CountAsync();
    }

    private IQueryable<ProductEntity> ApplyFilters(ProductFilter productFilter)
    {
        var query = _context.Product.AsQueryable();

        if (!string.IsNullOrEmpty(productFilter.Name))
            query = query.Where(p => p.Name.Contains(productFilter.Name));

        if (!string.IsNullOrEmpty(productFilter.Seller))
            query = query.Where(p => p.Seller.Name.Contains(productFilter.Seller));

        if (productFilter.Category.HasValue)
            query = query.Where(p => p.ProductType == productFilter.Category.Value);

        return query;
    }
}