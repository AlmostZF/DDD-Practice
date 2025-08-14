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

    public async Task<Result<List<OrderReservationDTO>>> ExecuteAsync()
    {
        try
        {
            var orderReservationDtos = await _orderReservationService.GetAllAsync();
            return Result<List<OrderReservationDTO>>.Success(orderReservationDtos,200);
        }
        catch (Exception e)
        {
            return Result<List<OrderReservationDTO>>.Failure("Erro ao buscar lista de compra", 500);
        }
    }
}