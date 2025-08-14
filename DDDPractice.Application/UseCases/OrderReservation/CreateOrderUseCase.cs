using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class CreateOrderUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public CreateOrderUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result> ExecuteAsync(OrderReservationDTO orderReservationDto)
    {
        try
        {
            await _orderReservationService.AddAsync(orderReservationDto);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao criar lista de compra", 500);
        }
    }
}