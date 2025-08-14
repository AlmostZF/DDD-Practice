using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Seller;

public class GetAllSellerUseCase
{
    private readonly SellerService _sellerService;

    public GetAllSellerUseCase(SellerService sellerService)
    {
        _sellerService = sellerService;
    }
    
    public async Task<Result<List<SellerDTO>>> ExecuteAsync()
    {
        try
        {
            var listSellerDto = await _sellerService.GetAllAsync();
            return Result<List<SellerDTO>>.Success(listSellerDto,200);
        }
        catch (Exception e)
        {
            return Result<List<SellerDTO>>.Failure("Erro ao buscar vendedores", 500);
        }
    }
}