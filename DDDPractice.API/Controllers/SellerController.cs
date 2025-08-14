using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SellerController: ControllerBase
{
    private readonly SellerService _sellerService;

    public SellerController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet]
    public async Task<IActionResult> getById([FromRoute] Guid id)
    {
        try
        {
            var sellerDto = await _sellerService.GetByIdAsync(id);
            var result = Result<SellerDTO>.Success(sellerDto,200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar vendedor", 500);
            return StatusCode(result.StatusCode, result);
        }  
        
    }
    
    [HttpGet]
    public async Task<IActionResult> getAll()
    {
        try
        {
            var sellerDto = await _sellerService.GetAllAsync();
            var result = Result<List<SellerDTO>>.Success(sellerDto,200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar vendedores", 500);
            return StatusCode(result.StatusCode, result);
        }  
        
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid id)
    {
        try
        {
             await _sellerService.DeleteAsync(id);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar vendedor", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SellerDTO sellerDto)
    {
        try
        {
            await _sellerService.AddAsync(sellerDto);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar vendedor", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SellerDTO sellerDto)
    {
        try
        {
            await _sellerService.UpdateAsync(sellerDto);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar vendedor", 500);
            return StatusCode(result.StatusCode, result);
        } 
    }
}