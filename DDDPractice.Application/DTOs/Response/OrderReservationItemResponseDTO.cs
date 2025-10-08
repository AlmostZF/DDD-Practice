namespace DDDPractice.Application.DTOs;

public class OrderReservationItemResponseDTO
{
    public Guid? Id { get; set; }
    public Guid? ReservationId { get; set; }
    public Guid ProductId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
    
    public string Name { get; set; }
    public string SellerName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
}