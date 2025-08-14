using DDDPractice.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderReservationController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar carrinho", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        try
        {
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao deletar carrinho", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }
    
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        try
        {
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao criar carrinho", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }
    
    [HttpPut]
    public async Task<IActionResult> Update()
    {
        try
        {
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao atualizar carrinho", 500);
            return StatusCode(result.StatusCode, result);
        } 
    } 
}