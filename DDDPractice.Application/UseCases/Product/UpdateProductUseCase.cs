using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Product;

public class UpdateProductUseCase
{
    private readonly ProductService _productService;

    public UpdateProductUseCase(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<Result> ExecuteAsync(ProductDTO productDto)
    {
        try
        {
            await _productService.UpdateAsync(productDto);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao atualizar produto", 500);
        }
    }
}