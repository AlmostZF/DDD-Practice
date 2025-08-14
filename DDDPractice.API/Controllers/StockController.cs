using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StockController: ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var StockList = await _stockService.GetAllAsync();
            var result = Result<List<StockDTO>>.Success(StockList, 200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar estoque", 500);
            return StatusCode(result.StatusCode, result);
        }
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var StockDto = await _stockService.GetByProductIdAsync(id);
            var result = Result<StockDTO>.Success(StockDto, 200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar estoque", 500);
            return StatusCode(result.StatusCode, result);
        }
    }
    

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StockDTO stockDto)
    {
        try
        {
            await _stockService.AddAsync(stockDto);
            var result = Result.Success(201);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar estoque", 500);
            return StatusCode(result.StatusCode, result);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Guid id, int Quantity )
    {
        try
        {
            await _stockService.UpdateQuantityAsync(id,Quantity);
            var result = Result.Success(200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            var result = Result.Failure("Erro ao buscar estoque", 500);
            return StatusCode(result.StatusCode, result);
        }   
    }
}