using System.ComponentModel.DataAnnotations.Schema;

namespace DDD_Practice.DDDPractice.Domain.Entities;

public class OrderReservationItemEntity
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid ProductId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    
    public ProductEntity Product { get; set; }
    public SellerEntity Seller { get; set; }
    
    [ForeignKey(nameof(ReservationId))]
    public OrderReservationEntity Reservation { get; set; }
}