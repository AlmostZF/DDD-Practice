namespace DDDPractice.Application.DTOs;

public class OrderReservationItemDTO
{
    public Guid? Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid ProductId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }

    public ProductResponseDTO ProductResponse { get; set; }

    public SellerResponseDTO SellerResponseDto { get; set; }
}