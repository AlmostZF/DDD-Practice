using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDDPractice.Application.DTOs;

public class ProductDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public int TotalQuantity { get; set; }
    public SellerDTO? Seller { get; set; }
    
    public Guid? SellerId { get; set; }
}
