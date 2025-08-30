using DDD_Practice.DDDPractice.Domain;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class OrderReservationMapper
{
    public static OrderReservationResponseDTO ToDto(OrderReservationEntity orderReservationEntity)
    {
        if (orderReservationEntity == null) return new OrderReservationResponseDTO();
        
        return new OrderReservationResponseDTO
        {
            Id = orderReservationEntity.Id,
            OrderStatus = orderReservationEntity.OrderStatus,
            PickupDate = orderReservationEntity.PickupDate,
            PickupDeadline = orderReservationEntity.PickupDeadline,
            PickupLocation =
            {
                Street = orderReservationEntity.PickupLocation.Street,
                City = orderReservationEntity.PickupLocation.City,
                State = orderReservationEntity.PickupLocation.State,
                Number = orderReservationEntity.PickupLocation.Number
            },
            ReservationDate = orderReservationEntity.ReservationDate,
            ReservationFee = orderReservationEntity.ReservationFee,
            SecurityCode = orderReservationEntity.SecurityCode,
            UserId = orderReservationEntity.UserId,
            ValueTotal = orderReservationEntity.ValueTotal,
            UserResponse = UserMapper.ToDto(orderReservationEntity.User),
            listOrderItens = OrderReservationItemMapper.ToDtoList(orderReservationEntity.ListOrderItems)
        };

    }

    public static List<OrderReservationResponseDTO> ToDtoList(IEnumerable<OrderReservationEntity> orderReservationEntity)
    {
        return orderReservationEntity.Select(ToDto).ToList();
    }


    public static OrderReservationEntity ToEntity(OrderReservationResponseDTO orderReservationResponseDto)
    {
        if (orderReservationResponseDto == null) return new OrderReservationEntity();
        
        return new OrderReservationEntity
        {
            Id = orderReservationResponseDto.Id!.Value,
            OrderStatus = orderReservationResponseDto.OrderStatus,
            PickupDate = orderReservationResponseDto.PickupDate,
            PickupDeadline = orderReservationResponseDto.PickupDeadline,
            PickupLocation =
            {
                Street = orderReservationResponseDto.PickupLocation.Street,
                City = orderReservationResponseDto.PickupLocation.City,
                State = orderReservationResponseDto.PickupLocation.State,
                Number = orderReservationResponseDto.PickupLocation.Number,
            },
            ReservationDate = orderReservationResponseDto.ReservationDate ?? new DateTime(),
            ReservationFee = orderReservationResponseDto.ReservationFee,
            SecurityCode = orderReservationResponseDto.SecurityCode,
            UserId = orderReservationResponseDto.UserId,
            ValueTotal = orderReservationResponseDto.ValueTotal
        };
    }
    
    public static List<OrderReservationEntity> ToEntitylist(List<OrderReservationResponseDTO> orderReservationDto)
    {
        return orderReservationDto.Select(ToEntity).ToList();
    }

}