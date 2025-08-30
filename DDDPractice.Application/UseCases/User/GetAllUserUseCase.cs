using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases;

public class GetAllUserUseCase
{
    public readonly IUserService _userService;

    public GetAllUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result<List<UserResponseDTO>>> ExecuteAsync()
    {
        try
        {
            var userList = await _userService.GetAllAsync();
                
            return Result<List<UserResponseDTO>>.Success(userList);
        }
        catch (Exception e)
        {
            return Result<List<UserResponseDTO>>.Failure("Erro ao buscar usuários", 500);
        }
    }
}