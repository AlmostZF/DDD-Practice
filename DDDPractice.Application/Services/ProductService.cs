using DDD_Practice.DDDPractice.Domain.Repositories;
using DDDPractice.Application.DTOs;
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

    public async Task<ProductDTO> GetByIdAsync(Guid id)
    {
        var productEntity = await _productRepository.GetByIdAsync(id);
        return ProductMapper.ToDto(productEntity);
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var productEntity = ProductMapper.ToEntity(productDto);
        await _productRepository.UpdateAsync(productEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task AddAsync(ProductDTO productDto)
    {
        var productEntity = ProductMapper.ToEntity(productDto);
        await _productRepository.AddAsync(productEntity);
    }

    public async Task<List<ProductDTO>> GetAllAsync()
    {
        var productEntity = await _productRepository.GetAllAsync();
         return ProductMapper.ToDtoList(productEntity);
    }
}