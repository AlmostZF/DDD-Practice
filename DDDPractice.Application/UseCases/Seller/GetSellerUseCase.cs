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
    
    public async Task<Result<SellerResponseDTO>> ExecuteAsync(Guid id)
    {
        try
        {
            var sellerDto = await _sellerService.GetByIdAsync(id);
            return Result<SellerResponseDTO>.Success(sellerDto,200);
        }
        catch (Exception e)
        {
            return Result<SellerResponseDTO>.Failure("Erro ao buscar vendedor", 500);
        }
    }
}