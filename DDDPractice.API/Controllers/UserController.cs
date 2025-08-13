using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllAsync();
            var result = Result<IEnumerable<UserEntity>>.Success(users, 200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar usuarios", 500);
            return StatusCode(result.StatusCode, result);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            var result = Result<UserDTO>.Success(user, 200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {
            var result = Result.Failure("Erro ao buscar usuário", 500);
            return StatusCode(result.StatusCode, result);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDto)
    {
        try
        {
            await _userService.UpdateAsync(userDto);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, "Usuário atualizado com sucesso");
        }
        catch (Exception e)
        {
            var result = Result.Failure("Erro ao atualizado usuário", 500);
            return StatusCode(result.StatusCode, result);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        try
        {
            var guid = await _userService.CreateAsync(userDto);
            var result = Result<Guid>.Success(guid, 201);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {
            var result = Result.Failure("Erro ao crear usuário", 500);
            return StatusCode(result.StatusCode, result);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        try
        {
            await _userService.DeleteAsync(id);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, "Usuário deletado");
        }
        catch (Exception e)
        {
            var result = Result.Failure("Erro ao deletar usuário", 500);
            return StatusCode(result.StatusCode, result);
        }
    }
}