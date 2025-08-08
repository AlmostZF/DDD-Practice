using DDD_Practice.DDDPractice.Domain.Entities;

namespace DDD_Practice.DDDPractice.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity> GetByIdAsync(Guid id);
    Task UpdateAsync (ProductEntity product);
    Task DeleteAsync(Guid id);
    Task AddAsync(ProductEntity product);
    Task<IEnumerable<ProductEntity>> GetAllAsync();
    

}