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

    public async Task<Result<UserDTO>> ExecuteAsync(Guid id)
    {
        try
        {
            var User = await _userService.GetByIdAsync(id);
            return Result<UserDTO>.Success(User);
        }
        catch (Exception e)
        {
            return Result<UserDTO>.Failure("Erro ao buscar usuário", 500);
        }
    }
}