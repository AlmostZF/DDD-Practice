using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases;

public class CreateUserUseCase
{
    private readonly IUserService _userService;

    public CreateUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result<Guid>> ExecuteAsync(UserDTO dto)
    {
        try
        {
            var userID = await _userService.CreateAsync(dto);
            return Result<Guid>.Success(userID);
        }
        catch (Exception e)
        {
            return Result<Guid>.Failure("Erro ao criar usuário");
        }
        
    }
}