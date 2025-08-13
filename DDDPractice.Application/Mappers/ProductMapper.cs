using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class ProductMapper
{
    public static ProductDTO ToDto(ProductEntity productEntity)
    {
        if (productEntity == null) return new ProductDTO();
        
        return new ProductDTO
        {
            Name = productEntity.Name,
            ProductType = productEntity.ProductType,
            TotalQuantity = productEntity.TotalQuantity,
            UnitPrice = productEntity.UnitPrice,
            Seller = SellerMapper.ToDto(productEntity.Seller)
        };

    }

    public static List<ProductDTO> ToDtoList(IEnumerable<ProductEntity> productEntity)
    {
        return productEntity.Select(ToDto).ToList();
    }


    public static ProductEntity ToEntity(ProductDTO productDto)
    {
        if (productDto == null) return new ProductEntity();
        
        return new ProductEntity
        {
            Name = productDto.Name,
            ProductType = productDto.ProductType,
            TotalQuantity = productDto.TotalQuantity,
            UnitPrice = productDto.UnitPrice
        };
    }
    
    public static List<ProductEntity> ToEntitylist(List<ProductDTO> productDto)
    {
        return productDto.Select(ToEntity).ToList();
    }



}