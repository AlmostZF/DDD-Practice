using DDD_Practice.DDDPractice.Domain.Repositories;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class ProductService: IProductService
{

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductResponseDTO> GetByIdAsync(Guid id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        return ProductMapper.ToDto(productEntity);
    }

    public async Task UpdateAsync(ProductUpdateDTO productUpdateDTO)
    {
        var existingProduct = await _productRepository.GetByIdAsync(productUpdateDTO.Id);
        if (existingProduct == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }

        ProductMapper.ToUpdateEntity(existingProduct, productUpdateDTO);    
        await _productRepository.UpdateAsync(existingProduct);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
    
    public async Task<Guid> AddAsync(ProductCreateDTO productCreateDTO)
    {
        var productEntity = ProductMapper.ToCreateEntity(productCreateDTO);
        await _productRepository.AddAsync(productEntity);
        return productEntity.Id;
    }

    public async Task<List<ProductResponseDTO>> GetAllAsync()
    {
        var productEntity = await _productRepository.GetAllAsync();
         return ProductMapper.ToDtoList(productEntity);
    }
}