namespace DDD_Practice.DDDPractice.Domain.Service;

public interface IReservationFeeCalculate
{
    public decimal CalculateFeeCalculate(OrderReservationEntity reservation);
}