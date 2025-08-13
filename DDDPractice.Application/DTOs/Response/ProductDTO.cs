using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDDPractice.Application.DTOs;

public class ProductDTO
{
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public int TotalQuantity { get; set; }
}