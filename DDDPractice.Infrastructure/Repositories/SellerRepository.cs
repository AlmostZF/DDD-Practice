using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Practice.DDDPractice.Infrastructure.Repositories;

public class SellerRepository: ISellerRepository
{
    private readonly AppDbContext _context;

    public SellerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SellerEntity> GetByIdAsync(Guid id)
    {
        var seller = await _context.Seller.FindAsync(id);
        if (seller == null)
            throw new Exception("Seller not found.");
        
        return seller; 
    }

    public async Task AddAsync(SellerEntity seller)
    {
        _context.Seller.Add(seller);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SellerEntity seller)
    {
        _context.Seller.Update(seller);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var seller = await _context.Seller.FindAsync(id);
        if (seller == null)
            throw new Exception("Seller not found.");
        
        _context.Seller.Remove(seller);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerator<SellerEntity>> GetAllAsync()
    {
        var listSeller = await _context.Seller.ToListAsync();
        return listSeller.GetEnumerator();
    }
}