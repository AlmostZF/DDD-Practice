using DDD_Practice.DDDPractice.Domain;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class OrderReservationMapper
{
    public static OrderReservationDTO ToDto(OrderReservationEntity orderReservationEntity)
    {
        if (orderReservationEntity == null) return new OrderReservationDTO();
        
        return new OrderReservationDTO
        {
            Id = orderReservationEntity.Id,
            OrderStatus = orderReservationEntity.OrderStatus,
            PickupDate = orderReservationEntity.PickupDate,
            PickupDeadline = orderReservationEntity.PickupDeadline,
            PickupLocation =
            {
                Street = orderReservationEntity.PickupLocation.Street,
                City = orderReservationEntity.PickupLocation.City,
                State = orderReservationEntity.PickupLocation.State
            },
            ReservationDate = orderReservationEntity.ReservationDate,
            ReservationFee = orderReservationEntity.ReservationFee,
            SecurityCode = orderReservationEntity.SecurityCode,
            UserId = orderReservationEntity.UserId,
            ValueTotal = orderReservationEntity.ValueTotal,
            User = UserMapper.ToDto(orderReservationEntity.User),
            listOrderItens = OrderReservationItemMapper.ToDtoList(orderReservationEntity.ListOrderItems)
        };

    }

    public static List<OrderReservationDTO> ToDtoList(IEnumerable<OrderReservationEntity> orderReservationEntity)
    {
        return orderReservationEntity.Select(ToDto).ToList();
    }


    public static OrderReservationEntity ToEntity(OrderReservationDTO orderReservationDto)
    {
        if (orderReservationDto == null) return new OrderReservationEntity();
        
        return new OrderReservationEntity
        {
            Id = orderReservationDto.Id,
            OrderStatus = orderReservationDto.OrderStatus,
            PickupDate = orderReservationDto.PickupDate,
            PickupDeadline = orderReservationDto.PickupDeadline,
            PickupLocation =
            {
                Street = orderReservationDto.PickupLocation.Street,
                City = orderReservationDto.PickupLocation.City,
                State = orderReservationDto.PickupLocation.State
            },
            ReservationDate = orderReservationDto.ReservationDate,
            ReservationFee = orderReservationDto.ReservationFee,
            SecurityCode = orderReservationDto.SecurityCode,
            UserId = orderReservationDto.UserId,
            ValueTotal = orderReservationDto.ValueTotal
        };
    }
    
    public static List<OrderReservationEntity> ToEntitylist(List<OrderReservationDTO> orderReservationDto)
    {
        return orderReservationDto.Select(ToEntity).ToList();
    }

}