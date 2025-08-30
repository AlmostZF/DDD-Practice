using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Guid> CreateAsync(UserCreateDTO userCreateDTO)
    {
        var user = UserMapper.ToCreateEntity(userCreateDTO);
        
        await _userRepository.CreateAsync(user);
        return user.Id;
    }
    
    public async Task<UserResponseDTO> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return null;
        }
        
        return new UserResponseDTO(user.SecurityCode)
        {
            Id = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber
        };
    }

    public async Task<List<UserResponseDTO>> GetAllAsync()
    {
        var listUser = await _userRepository.GetAllAsync();
        return UserMapper.ToDtoList(listUser);
    }
    

    public async Task UpdateAsync(UserUpdateDTO userUpdateDTO)
    {
        var existingUser = await _userRepository.GetByIdAsync(userUpdateDTO.Id);
        if (existingUser == null)
        {
            throw new InvalidOperationException("Usuário não encontrado.");
        }
        
        UserMapper.ToUpdateEntity(existingUser, userUpdateDTO);
        
        await _userRepository.UpdateAsync(existingUser);
        
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
}