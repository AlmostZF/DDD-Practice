namespace DDDPractice.Application.DTOs.Request.ProductCreateDTO;

public class OrderReservationItemCreateDTO
{
    //public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
}