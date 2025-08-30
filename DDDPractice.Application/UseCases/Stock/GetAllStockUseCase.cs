using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Stock;

public class GetAllStockUseCase
{
    private readonly IStockService _stockService;

    public GetAllStockUseCase(IStockService stockService)
    {
        _stockService = stockService;
    }
    
    public async Task<Result<List<StockResponseDTO>>> ExecuteAsync()
    {
        try
        {
            var listStockDTO = await _stockService.GetAllAsync();
            return Result<List<StockResponseDTO>>.Success(listStockDTO,200);
        }
        catch (Exception e)
        {
            return Result<List<StockResponseDTO>>.Failure("Erro ao buscar estoque", 500);
        }
        
    }
}