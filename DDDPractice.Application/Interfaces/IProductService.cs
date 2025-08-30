using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Interfaces;

public interface IProductService
{
    Task<ProductResponseDTO> GetByIdAsync(Guid id);
    Task UpdateAsync (ProductUpdateDTO productUpdate);
    Task DeleteAsync(Guid id);
    Task<Guid> AddAsync(ProductCreateDTO productCreateDTO);
    Task<List<ProductResponseDTO>> GetAllAsync();
}