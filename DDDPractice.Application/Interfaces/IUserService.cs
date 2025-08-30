using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Interfaces;

public interface IUserService
{
    Task<UserResponseDTO> GetByIdAsync(Guid id);
    Task<List<UserResponseDTO>> GetAllAsync(); 
    Task<Guid> CreateAsync(UserCreateDTO userCreateDto);
    Task UpdateAsync(UserUpdateDTO userUpdateDTO);
    Task DeleteAsync(Guid id);
}