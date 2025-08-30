using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDDPractice.Application.DTOs.Request.ProductCreateDTO;

public class ProductCreateDTO
{
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid SellerId { get; set; }
}