using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.UseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController: ControllerBase
{
    
    private readonly CreateProductUseCase _createProductUseCase;
    private readonly DeleteProductUseCase _deleteProductUseCase;
    private readonly GetAllProductUseCase _getAllProductUseCase;
    private readonly GetProductUseCase _getProductUseCase;
    private readonly UpdateProductUseCase _updateProductUseCase;

    public ProductController(
        CreateProductUseCase createProductUseCase,
        DeleteProductUseCase deleteProductUseCase,
        GetAllProductUseCase getAllProductUseCase,
        GetProductUseCase getProductUseCase,
        UpdateProductUseCase updateProductUseCase
        )
    {
        _createProductUseCase = createProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
        _getAllProductUseCase = getAllProductUseCase;
        _getProductUseCase = getProductUseCase;
        _updateProductUseCase = updateProductUseCase;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var result = await _getProductUseCase.ExecuteAsync(id);

        return result.Value != null
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllProductUseCase.ExecuteAsync();

        return result.Value != null
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        var result = await _deleteProductUseCase.ExecuteAsync(id);

        return result.Message != null
            ? Ok(result.Message)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]ProductCreateDTO productCreateDTO)
    {
        var result = await _createProductUseCase.ExecuteAsync(productCreateDTO);

        return result.Message != null
            ? Created()
            : BadRequest(result.Error);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]ProductUpdateDTO productUpdateDto)
    {
        var result = await _updateProductUseCase.ExecuteAsync(productUpdateDto);

        return result.Message != null
            ? Ok(result.Message)
            : BadRequest(result.Error);
    } 
}