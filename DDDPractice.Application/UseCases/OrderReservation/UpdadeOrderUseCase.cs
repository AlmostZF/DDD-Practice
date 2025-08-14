using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class UpdadeOrderUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public UpdadeOrderUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result> ExecuteAsync(OrderReservationDTO orderReservationDto)
    {
        try
        {
            await _orderReservationService.UpdateAsync(orderReservationDto);
            return Result.Success(200);
        }
        catch (Exception e)
        {
            return Result.Failure("Erro ao atualizar lista de compra", 500);
        }
    }
}