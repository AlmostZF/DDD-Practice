using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public static class UserMapper
{
    public static UserDTO ToDto(UserEntity userEntity)
    {
        if (userEntity == null) return new UserDTO(null);
        
        return new UserDTO(userEntity.SecurityCode)
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            PhoneNumber = userEntity.PhoneNumber
        };

    }

    public static List<UserDTO> ToDtoList(IEnumerable<UserEntity> userEntity)
    {
        return userEntity.Select(ToDto).ToList();
    }


    public static UserEntity ToEntity(UserDTO userDto)
    {
        if (userDto == null) return new UserEntity(null);
        
        return new UserEntity(userDto.SecurityCode)
        {
            Id = userDto.Id!.Value,
            Name = userDto.Name,
            PhoneNumber = userDto.PhoneNumber
        }; 
    }
    
    public static List<UserEntity> ToEntitylist(List<UserDTO> userDto)
    {
        return userDto.Select(ToEntity).ToList();
    }

    
    
}