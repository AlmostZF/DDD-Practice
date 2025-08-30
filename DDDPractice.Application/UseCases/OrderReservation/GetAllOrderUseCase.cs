using DDD_Practice.DDDPractice.Domain.Enums;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class GetAllOrderUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public GetAllOrderUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result<List<OrderReservationResponseDTO>>> ExecuteAsync()
    {
        try
        {
            var orderReservationDtos = await _orderReservationService.GetAllAsync();
            return Result<List<OrderReservationResponseDTO>>.Success(orderReservationDtos,200);
        }
        catch (Exception e)
        {
            return Result<List<OrderReservationResponseDTO>>.Failure("Erro ao buscar lista de compra", 500);
        }
    }
}