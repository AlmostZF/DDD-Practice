using System.Text.Json.Serialization;
using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;

namespace DDDPractice.Application.DTOs.Request.ProductCreateDTO;

public class OrderReservationCreateDTO
{

    public SecurityCode SecurityCode { get; set; }
    public Guid UserId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime PickupDeadline { get; set; }
    public PickupLocation PickupLocation { get; set; }
    public StatusOrder OrderStatus { get; set; }
    
    [JsonPropertyName("listOrderItens")] 
    public List<OrderReservationItemResponseDTO> listOrderItens { get; set; }
    

}