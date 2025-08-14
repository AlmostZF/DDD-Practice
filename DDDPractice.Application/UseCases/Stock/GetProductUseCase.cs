using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Stock;

public class GetProductUseCase
{
    private readonly IStockService _stockService;

    public GetProductUseCase(IStockService stockService)
    {
        _stockService = stockService;
    }
    
    public async Task<Result<StockDTO>> ExecuteAsync(Guid productId)
    {
        try
        {
            var stockDTO = await _stockService.GetByProductIdAsync(productId);
            return Result<StockDTO>.Success(stockDTO, 200);
        }
        catch (Exception e)
        {
            return Result<StockDTO>.Failure("Erro ao buscar estoque", 500);
        }
        
    }
}