using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Interfaces;

public interface ISellerService
{
    Task<SellerResponseDTO> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(SellerCreateDTO sellerCreate);
    Task UpdateAsync(SellerUpdateDTO sellerUpdate);
    Task DeleteAsync(Guid id);
    Task<List<SellerResponseDTO>> GetAllAsync();
}