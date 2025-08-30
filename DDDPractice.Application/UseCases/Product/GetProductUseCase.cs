using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Product;

public class GetProductUseCase
{
    private readonly ProductService _productService;

    public GetProductUseCase(ProductService productService)
    {
        _productService = productService;
    }
    public async Task<Result<ProductResponseDTO>> ExecuteAsync(Guid id)
    {
        try
        {
            var productDto = await _productService.GetByIdAsync(id);
            return Result<ProductResponseDTO>.Success(productDto,200);
        }
        catch (Exception e)
        {
            return Result<ProductResponseDTO>.Failure("Erro ao buscar produto", 500);
        }
    }
}