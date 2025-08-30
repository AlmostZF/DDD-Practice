using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Mappers;

public class ProductMapper
{
    public static ProductResponseDTO ToDto(ProductEntity productEntity)
    {
        if (productEntity == null) return new ProductResponseDTO();
        
        
        return new ProductResponseDTO
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            ProductType = productEntity.ProductType, 
            UnitPrice = productEntity.UnitPrice,
            Seller = SellerMapper.ToDto(productEntity.Seller),
            
        };

    }

    public static List<ProductResponseDTO> ToDtoList(IEnumerable<ProductEntity> productEntity)
    {
        return productEntity.Select(ToDto).ToList();
    }


    public static ProductEntity ToEntity(ProductCreateDTO productCreateDto)
    {
        if (productCreateDto == null) return new ProductEntity();
        
        return new ProductEntity
        {
            Id = Guid.NewGuid(),
            Name = productCreateDto.Name,
            ProductType = productCreateDto.ProductType,
            UnitPrice = productCreateDto.UnitPrice,
            SellerId = productCreateDto.SellerId
        };
    }
    
    public static ProductEntity ToCreateEntity(ProductCreateDTO productCreateDto)
    {
        if (productCreateDto == null) return new ProductEntity();
    
        return new ProductEntity
        {
            Id = Guid.NewGuid(),
            Name = productCreateDto.Name,
            ProductType = productCreateDto.ProductType,
            UnitPrice = productCreateDto.UnitPrice,
            SellerId = productCreateDto.SellerId
        };
    }
    
    public static void ToUpdateEntity(ProductEntity productEntity, ProductUpdateDTO productUpdateDto)
    {
        {
            productEntity.Id = productUpdateDto.Id;
            productEntity.Name = productUpdateDto.Name;
            productEntity.ProductType = productUpdateDto.ProductType;
            productEntity.UnitPrice = productUpdateDto.UnitPrice;
            productEntity.SellerId = productUpdateDto.SellerId;
        };
    }
    
    public static List<ProductEntity> ToEntitylist(List<ProductCreateDTO> productDto)
    {
        return productDto.Select(ToEntity).ToList();
    }



}