namespace DDD_Practice.DDDPractice.Domain.ValueObjects;

public class PickupLocation
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public PickupLocation(string street, string city, string state)
    {
        Street = street;
        City = city;
        State = state;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is not PickupLocation other)
            return false;

        return Street == other.Street &&
               City == other.City &&
               State == other.State;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, State);
    }
    
    
}