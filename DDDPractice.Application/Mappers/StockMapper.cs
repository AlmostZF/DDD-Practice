using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class StockMapper
{
    public static StockDTO ToDto(StockEntity stockEntity)
    {
        if (stockEntity == null) return new StockDTO();

        return new StockDTO
        {
            Id = stockEntity.Id,
            Product = ProductMapper.ToDto(stockEntity.Product),
            Quantity = stockEntity.Quantity,
            MovementDate = stockEntity.MovementDate,
            ProductId = stockEntity.ProductId,
        };

    }

    public static List<StockDTO> ToDtoList(IEnumerable<StockEntity> stockEntity)
    {
        return stockEntity.Select(ToDto).ToList();
    }


    public static StockEntity ToEntity(StockDTO stockDto)
    {
        if (stockDto == null) return new StockEntity();
        
        return new StockEntity
        {
            Id = stockDto.Id,
            Quantity = stockDto.Quantity,
            MovementDate = stockDto.MovementDate,
            ProductId = stockDto.ProductId,
        };

    }
    
    public static List<StockEntity> ToEntitylist(List<StockDTO> stockDto)
    {
        return stockDto.Select(ToEntity).ToList();
    }

}