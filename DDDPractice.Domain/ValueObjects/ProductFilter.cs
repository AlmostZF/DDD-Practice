using DDD_Practice.DDDPractice.Domain.Enums;

namespace DDD_Practice.DDDPractice.Domain.ValueObjects;

public class ProductFilter
{
    public ProductType? Category { get; private set; }
    public string? Name { get; private set; }
    public string? Seller { get; private set; }
    public int PageNumber { get; private set; } = 1;
    public int MaxItensPerPage { get; private set; } = 10;

    public ProductFilter(
        ProductType? category,
        string? name,
        string? seller,
        int? pageNumber,
        int? maxItensPerPage
    )
    {
        Category = category;
        Name = name;
        Seller = seller;
        PageNumber = pageNumber ?? 1;
        MaxItensPerPage = maxItensPerPage ?? 10;
    }
}