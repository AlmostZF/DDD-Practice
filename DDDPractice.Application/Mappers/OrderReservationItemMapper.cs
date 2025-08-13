using DDD_Practice.DDDPractice.Domain;
using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public static class OrderReservationItemMapper
{
    public static OrderReservationItemDTO ToDto(OrderReservationItemEntity orderReservationItemEntity)
    {
        if (orderReservationItemEntity == null) return new OrderReservationItemDTO();
        
        return new OrderReservationItemDTO
        {
            Id = orderReservationItemEntity.Id,
            Quantity = orderReservationItemEntity.Quantity,
            ProductId = orderReservationItemEntity.ProductId,
            ReservationId = orderReservationItemEntity.ReservationId,
            SellerId = orderReservationItemEntity.SellerId,
            TotalPrice = orderReservationItemEntity.TotalPrice,
            UnitPrice = orderReservationItemEntity.UnitPrice,
            Product = ProductMapper.ToDto(orderReservationItemEntity.Product),
            SellerDto = SellerMapper.ToDto(orderReservationItemEntity.Seller)
        };

    }

    public static List<OrderReservationItemDTO> ToDtoList(IEnumerable<OrderReservationItemEntity> orderReservationItemEntity)
    {
        return orderReservationItemEntity.Select(ToDto).ToList();
    }


    public static OrderReservationItemEntity ToEntity(OrderReservationItemDTO orderReservationDto)
    {
        if (orderReservationDto == null) return new OrderReservationItemEntity();
        
        return new OrderReservationItemEntity
        {
            Id = orderReservationDto.Id,
            Quantity = orderReservationDto.Quantity,
            ProductId = orderReservationDto.ProductId,
            ReservationId = orderReservationDto.ReservationId,
            SellerId = orderReservationDto.SellerId,
            TotalPrice = orderReservationDto.TotalPrice,
            UnitPrice = orderReservationDto.UnitPrice
        };
    }
    
    public static List<OrderReservationItemEntity> ToEntitylist(List<OrderReservationItemDTO> orderReservationDto)
    {
        return orderReservationDto.Select(ToEntity).ToList();
    }
}