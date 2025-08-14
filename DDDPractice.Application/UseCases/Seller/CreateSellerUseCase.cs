using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Seller;

public class CreateSellerUseCase
{
    private readonly SellerService _sellerService;

    public CreateSellerUseCase(SellerService sellerService)
    {
        _sellerService = sellerService;
    }
    
    public async Task<Result> ExecuteAsync(SellerDTO sellerDto)
    {
        try
        {
           await _sellerService.AddAsync(sellerDto);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao crair vendedor", 500);
        }
    }
}
