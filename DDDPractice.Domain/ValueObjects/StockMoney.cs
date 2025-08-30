namespace DDD_Practice.DDDPractice.Domain.ValueObjects;

public class StockMoney
{
    public decimal Amount { get; private set; }

    public static StockMoney CalculateTotal(decimal unitPrice, int quantity)
    {
        return new StockMoney(unitPrice * quantity);
    }
}