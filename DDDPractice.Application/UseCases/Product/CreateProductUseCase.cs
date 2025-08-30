using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
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
    
    public async Task<Result> ExecuteAsync(ProductCreateDTO productCreateDTO)
    {
        try
        {
            await _productService.AddAsync(productCreateDTO);
            return Result.Success("Produto criado com sucesso",200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao criar Produto", 500);
        }
    }
}