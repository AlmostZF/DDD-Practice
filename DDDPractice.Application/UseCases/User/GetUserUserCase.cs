using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases;

public class GetUserUserCase
{
    public readonly IUserService _userService;

    public GetUserUserCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result<UserResponseDTO>> ExecuteAsync(Guid id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            return Result<UserResponseDTO>.Success(user);
        }
        catch (Exception e)
        {
            return Result<UserResponseDTO>.Failure("Erro ao buscar usuário", 500);
        }
    }
}