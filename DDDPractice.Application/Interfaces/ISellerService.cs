using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface ISellerService
{
    Task<SellerDTO> GetByIdAsync(Guid id);
    Task AddAsync(SellerDTO seller);
    Task UpdateAsync(SellerDTO seller);
    Task DeleteAsync(Guid id);
    Task<List<SellerDTO>> GetAllAsync();
}