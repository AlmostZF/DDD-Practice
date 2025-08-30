using DDD_Practice.DDDPractice.Domain.Entities;

namespace DDDPractice.Application.DTOs;

public class StockDTO
{
    public Guid? Id { get; set; }
    public Guid? ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime? MovementDate { get; set; }

    public ProductResponseDTO? Product { get; set; }
}