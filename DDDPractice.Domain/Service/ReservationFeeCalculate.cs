namespace DDD_Practice.DDDPractice.Domain.Service;

public class ReservationFeeCalculate : IReservationFeeCalculate
{
    public decimal CalculateFeeCalculate(OrderReservationEntity reservation)
    {
        return reservation.ValueTotal * 0.10m;
    }
}