using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> GetByIdAsync(Guid id);
    Task<IEnumerable<UserEntity>> GetAllAsync(); 
    Task<Guid> CreateAsync(UserDTO userDto);
    Task UpdateAsync(UserDTO userDto);
    Task DeleteAsync(Guid id);
}