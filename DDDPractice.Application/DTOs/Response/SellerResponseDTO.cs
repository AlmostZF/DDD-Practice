using DDD_Practice.DDDPractice.Domain.ValueObjects;

namespace DDDPractice.Application.DTOs;

public class SellerDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public PickupLocation? PickupLocation { get; private set; }
    
    public SellerDTO(PickupLocation pickupLocation)
    {
        PickupLocation = pickupLocation;
    }
}