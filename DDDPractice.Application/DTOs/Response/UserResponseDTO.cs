using DDD_Practice.DDDPractice.Domain.ValueObjects;

namespace DDDPractice.Application.DTOs;

public class UserResponseDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    
    public SecurityCode? SecurityCode { get; private set; }
    
    public UserResponseDTO(SecurityCode securityCode)
    {
        SecurityCode = securityCode;
    }
    
}