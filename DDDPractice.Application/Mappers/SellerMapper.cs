using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class SellerMapper
{
    public static SellerDTO ToDto(SellerEntity sellerEntity)
    {
        if (sellerEntity == null) return new SellerDTO();
        
        return new SellerDTO
        {
            Id = sellerEntity.Id,
            Name = sellerEntity.Name ,
            PhoneNumber = sellerEntity.PhoneNumber,
            PickupLocation = 
            {  
                City  = sellerEntity.PickupLocation.City, 
                State = sellerEntity.PickupLocation.State, 
                Street = sellerEntity.PickupLocation.Street
            }
        };

    }

    public static List<SellerDTO> ToDtoList(IEnumerable<SellerEntity> sellerEntity)
    {
        return sellerEntity.Select(ToDto).ToList();
    }


    public static SellerEntity ToEntity(SellerDTO sellerDto)
    {
        if (sellerDto == null) return new SellerEntity();
        
        return new SellerEntity
        {
            Id = sellerDto.Id,
            Name = sellerDto.Name ,
            PhoneNumber = sellerDto.PhoneNumber,
            PickupLocation = { City  = sellerDto.PickupLocation.City, 
                State = sellerDto.PickupLocation.State, 
                Street = sellerDto.PickupLocation.Street}
        };
    }
    
    public static List<SellerEntity> ToEntitylist(List<SellerDTO> sellerDto)
    {
        return sellerDto.Select(ToEntity).ToList();
    }

}