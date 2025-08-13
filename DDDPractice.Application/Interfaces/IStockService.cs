using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface IStockService
{
    Task<List<StockDTO>> GetAllAsync();
    Task<StockDTO> GetByProductIdAsync(Guid productId);
    Task UpdateQuantityAsync(Guid productId, int newQuantity);
    Task AddAsync(StockDTO stock);

}