using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface IProductService
{
    Task<ProductDTO> GetByIdAsync(Guid id);
    Task UpdateAsync (ProductDTO product);
    Task DeleteAsync(Guid id);
    Task AddAsync(ProductDTO product);
    Task<List<ProductDTO>> GetAllAsync();
}