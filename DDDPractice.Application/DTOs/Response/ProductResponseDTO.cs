using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDDPractice.Application.DTOs;

public class ProductResponseDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public SellerResponseDTO Seller { get; set; }
}
