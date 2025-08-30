using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Interfaces;

public interface IStockService
{
    Task<List<StockResponseDTO>> GetAllAsync();
    Task<StockResponseDTO> GetByIdAsync(Guid productId);
    Task UpdateQuantityAsync(StockUpdateDTO stockUpdateDto);
    Task AddAsync(StockCreateDTO stockCreateDTO);

}