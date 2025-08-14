using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Stock;

public class UpdateQuantityUseCase
{
    private readonly IStockService _stockService;

    public UpdateQuantityUseCase(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Result> ExecuteAsync(Guid productId, int newQuantity)
    {
        try
        {
            await _stockService.UpdateQuantityAsync(productId, newQuantity);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao atualizar estoque", 500);
        }
        
    }
}