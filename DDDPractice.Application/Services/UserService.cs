using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;

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
        var securityCode = new SecurityCode(GenerateRandomCode());
        var user = new UserEntity(securityCode)
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            PhoneNumber = userDto.PhoneNumber,
        };
        
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

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }


    public async Task UpdateAsync(UserDTO userDto)
    {
        var userEntity = new UserEntity(userDto.SecurityCode)
        {
            Id = userDto.Id,
            Name = userDto.PhoneNumber,
            PhoneNumber = userDto.PhoneNumber
        };
        await _userRepository.UpdateAsync(userEntity);
        
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    private string GenerateRandomCode()
    {
        var random = new Random();
        return random.Next(1000, 9999).ToString();
    }
}