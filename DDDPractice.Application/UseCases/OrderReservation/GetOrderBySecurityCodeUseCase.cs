using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class GetOrderBySecurityCodeUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public GetOrderBySecurityCodeUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result<List<OrderReservationDTO>>> ExecuteAsync(StatusOrder status)
    {
        try
        {
            var orderReservationDtos = await _orderReservationService.GetByStatusAsync(status);
            return Result<List<OrderReservationDTO>>.Success(orderReservationDtos,200);
        }
        catch (Exception e)
        {
            return Result<List<OrderReservationDTO>>.Failure("Erro ao buscar lista de compra", 500);
        }
    }
}