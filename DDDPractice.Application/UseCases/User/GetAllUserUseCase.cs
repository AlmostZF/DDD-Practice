using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases;

public class GetAllUserUseCase
{
    public readonly IUserService _userService;

    public GetAllUserUseCase(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Result<IEnumerable<UserEntity>>> ExecuteAsync()
    {
        try
        {
            var UserList = await _userService.GetAllAsync();

            return Result<IEnumerable<UserEntity>>.Success(UserList);
        }
        catch (Exception e)
        {
            return Result<IEnumerable<UserEntity>>.Failure("Erro ao buscar usuários", 500);
        }
    }
}