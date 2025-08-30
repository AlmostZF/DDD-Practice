using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Mappers;

public static class UserMapper
{
    public static UserResponseDTO ToDto(UserEntity userEntity)
    {
        if (userEntity == null) return new UserResponseDTO(null);
        
        return new UserResponseDTO(userEntity.SecurityCode)
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            PhoneNumber = userEntity.PhoneNumber
        };

    }



    public static List<UserResponseDTO> ToDtoList(IEnumerable<UserEntity> userEntity)
    {
        return userEntity.Select(ToDto).ToList();
    }


    public static UserEntity ToEntity(UserResponseDTO userResponseDto)
    {
        var securityCode = new SecurityCode(GenerateUniqueCodeFromGuid());
        if (userResponseDto == null) return new UserEntity(null);
        
        return new UserEntity(securityCode)
        {
            Id = userResponseDto.Id ?? Guid.NewGuid(),
            Name = userResponseDto.Name,
            PhoneNumber = userResponseDto.PhoneNumber
        }; 
    }
    public static void ToUpdateEntity(UserEntity userEntity, UserUpdateDTO userUpdateDto)
    {
        if (userUpdateDto == null) return;

        {
            userEntity.Id = userUpdateDto.Id;
            userEntity.Name = userUpdateDto.Name;
            userEntity.PhoneNumber = userUpdateDto.PhoneNumber;
        };
    }
    
    public static UserEntity ToCreateEntity(UserCreateDTO userCreateDto)
    {
        var securityCode = new SecurityCode(GenerateUniqueCodeFromGuid());
        if (userCreateDto == null) return new UserEntity(null);
        
        return new UserEntity(securityCode)
        {
            Id = Guid.NewGuid(),
            Name = userCreateDto.Name,
            PhoneNumber = userCreateDto.PhoneNumber
        }; 
    }
    
    public static List<UserEntity> ToEntitylist(List<UserResponseDTO> userDto)
    {
        return userDto.Select(ToEntity).ToList();
    }

    private static string GenerateUniqueCodeFromGuid(int length = 4)
    {
        return Guid.NewGuid().ToString("N").Substring(0, length);
    }
    
}