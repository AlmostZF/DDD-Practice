using System.Collections;
using DDD_Practice.DDDPractice.Domain.Entities;

namespace DDD_Practice.DDDPractice.Domain.Repositories;

public interface IStockRepository
{
    Task<IEnumerable<StockEntity>> GetAllAsync();
    Task<StockEntity> GetByProductIdAsync(Guid productId);
    Task UpdateQuantityAsync(Guid productId, int newQuantity);
    Task AddAsync(StockEntity stock);

}