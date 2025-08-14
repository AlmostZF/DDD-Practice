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

    public async Task<Result<List<OrderReservationDTO>>> ExecuteAsync(SecurityCode securityCode)
    {
        try
        {
            var orderReservationDtos = await _orderReservationService.GetBySecurityCodeAsync(securityCode);
            return Result<List<OrderReservationDTO>>.Success(orderReservationDtos,200);
        }
        catch (Exception e)
        {
            return Result<List<OrderReservationDTO>>.Failure("Erro ao busacar lista de compra", 500);
        }
    }
}