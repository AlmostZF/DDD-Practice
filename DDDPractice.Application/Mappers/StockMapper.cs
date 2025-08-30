using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Mappers;

public class StockMapper
{
    public static StockResponseDTO ToDto(StockEntity stockEntity)
    {
        if (stockEntity == null) return new StockResponseDTO();

        return new StockResponseDTO
        {
            Id = stockEntity.Id,
            Product = ProductMapper.ToDto(stockEntity.Product),
            Quantity = stockEntity.Quantity,
            MovementDate = stockEntity.MovementDate,
            ProductId = stockEntity.ProductId,
            Total = StockMoney.CalculateTotal(stockEntity.Product.UnitPrice, stockEntity.Quantity).Amount,
        };

    }

    public static List<StockResponseDTO> ToDtoList(IEnumerable<StockEntity> stockEntity)
    {
        return stockEntity.Select(ToDto).ToList();
    }


    public static StockEntity ToEntity(StockResponseDTO stockResponseDto)
    {
        if (stockResponseDto == null) return new StockEntity();
        
        return new StockEntity
        {
            Id = stockResponseDto.Id ?? Guid.NewGuid(),
            Quantity = stockResponseDto.Quantity,
            MovementDate = stockResponseDto.MovementDate ?? new DateTime(),
            ProductId = stockResponseDto.ProductId!.Value,
        };

    }
    
    public static StockEntity ToCreateEntity(StockCreateDTO stockCreateDTO, decimal produtUnitPrice)
    {
        if (stockCreateDTO == null) return new StockEntity();
        
        return new StockEntity
        {
            Id = Guid.NewGuid(),
            Quantity = stockCreateDTO.Quantity,
            MovementDate = new DateTime(),
            ProductId = stockCreateDTO.ProductId,
            Total = StockMoney.CalculateTotal(produtUnitPrice, stockCreateDTO.Quantity).Amount,
            
        };

    }
    
    public static void ToUpdateEntity(StockEntity stockEntity, StockUpdateDTO stockUpdateDTO)
    {

        {
            stockEntity.Quantity = stockUpdateDTO.Quantity; 
            stockEntity.MovementDate = new DateTime();
            stockEntity.Total = StockMoney.CalculateTotal(stockEntity.Product.UnitPrice, stockUpdateDTO.Quantity).Amount;
        }

    }
    
    public static List<StockEntity> ToEntitylist(List<StockResponseDTO> stockDto)
    {
        return stockDto.Select(ToEntity).ToList();
    }

}