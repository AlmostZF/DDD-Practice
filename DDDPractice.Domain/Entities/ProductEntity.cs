using System.ComponentModel.DataAnnotations.Schema;
using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDD_Practice.DDDPractice.Domain.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid SellerId { get; set; }
    
    [ForeignKey(nameof(SellerId))]
    public SellerEntity? Seller { get; set; }
}