using DDDPractice.Application.DTOs;
using DDDPractice.Application.Services;
using DDDPractice.Application.Shared;

namespace DDDPractice.Application.UseCases.OrderReservation;

public class GetOrderUseCase
{
    private readonly OrderReservationService _orderReservationService;

    public GetOrderUseCase(OrderReservationService orderReservationService)
    {
        _orderReservationService = orderReservationService;
    }

    public async Task<Result<OrderReservationDTO>> ExecuteAsync(Guid id)
    {
        try
        {
           var orderReservationDto = await _orderReservationService.GetByIdAsync(id);
            return Result<OrderReservationDTO>.Success(orderReservationDto,200);
        }
        catch (Exception e)
        {
            return Result<OrderReservationDTO>.Failure("Erro ao criar lista de compra", 500);
        }
    }
}