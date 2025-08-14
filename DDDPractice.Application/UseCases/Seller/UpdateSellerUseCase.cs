using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Seller;

public class UpdateSellerUseCase
{
    private readonly SellerService _sellerService;

    public UpdateSellerUseCase(SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    public async Task<Result> ExecuteAsync(SellerDTO sellerDto)
    {
        try
        {
            await _sellerService.UpdateAsync(sellerDto);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao atualizar vendedor", 500);
        }
    }
}