using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Seller;

public class DeleteSellerUseCase
{
    private readonly SellerService _sellerService;

    public DeleteSellerUseCase(SellerService sellerService)
    {
        _sellerService = sellerService;
    }
    
    public async Task<Result> ExecuteAsync(Guid id)
    {
        try
        {
            _sellerService.DeleteAsync(id);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao remover vendedor", 500);
        }
    }
}