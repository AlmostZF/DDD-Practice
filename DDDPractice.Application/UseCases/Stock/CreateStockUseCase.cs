using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;


namespace DDDPractice.Application.UseCases.Stock;

public class CreateStockUseCase
{
    private readonly IStockService _stockService;

    public CreateStockUseCase(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Result> ExecuteAsync(StockDTO stock)
    {
        try
        {
            _stockService.AddAsync(stock);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao criar estoque", 500);
        }
        
    }
}