using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Seller;

public class GetSellerUseCase
{
    private readonly SellerService _sellerService;

    public GetSellerUseCase(SellerService sellerService)
    {
        _sellerService = sellerService;
    }
    
    public async Task<Result<SellerDTO>> ExecuteAsync(Guid id)
    {
        try
        {
            var sellerDto = await _sellerService.GetByIdAsync(id);
            return Result<SellerDTO>.Success(sellerDto,200);
        }
        catch (Exception e)
        {
            return Result<SellerDTO>.Failure("Erro ao buscar vendedor", 500);
        }
    }
}