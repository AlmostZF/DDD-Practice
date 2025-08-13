using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
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
    
    public async Task<Guid> CreateAsync(UserDTO userDto)
    {
        var securityCode = new SecurityCode(GenerateUniqueCodeFromGuid());
        var user = UserMapper.ToEntity(userDto);
        
        await _userRepository.CreateAsync(user);
        return user.Id;
    }
    
    public async Task<UserDTO> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        return new UserDTO(user.SecurityCode)
        {
            Id = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber
        };
    }

    public async Task<List<UserDTO>> GetAllAsync()
    {
        var listUser = await _userRepository.GetAllAsync();
        return UserMapper.ToDtoList(listUser);
    }


    public async Task UpdateAsync(UserDTO userDto)
    {
        var userEntity = UserMapper.ToEntity(userDto);
        await _userRepository.UpdateAsync(userEntity);
        
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    private string GenerateUniqueCodeFromGuid(int length = 4)
    {
        return Guid.NewGuid().ToString("N").Substring(0, length);
    }
}