using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class GetOrderByStatusUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public GetOrderByStatusUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result<List<OrderReservationResponseDTO>>> ExecuteAsync(StatusOrder securityCode)
    {
        try
        {
            var orderReservationDtos = await _orderReservationService.GetByStatusAsync(securityCode);
            return Result<List<OrderReservationResponseDTO>>.Success(orderReservationDtos,200);
        }
        catch (Exception e)
        {
            return Result<List<OrderReservationResponseDTO>>.Failure("Erro ao busacar lista de compra", 500);
        }
    }
}