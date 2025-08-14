using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.Product;

public class CreateProductUseCase
{
    private readonly ProductService _productService;

    public CreateProductUseCase(ProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<Result> ExecuteAsync(ProductDTO product)
    {
        try
        {
            await _productService.AddAsync(product);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao criar Produto", 500);
        }
    }
}