using DDD_Practice.DDDPractice.Domain.Entities;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Mappers;

public class SellerMapper
{
    public static SellerDTO ToDto(SellerEntity sellerEntity)
    {
        if (sellerEntity == null) return new SellerDTO(null);
        
        return new SellerDTO(sellerEntity.PickupLocation)
        {
            Id = sellerEntity.Id,
            Name = sellerEntity.Name ,
            PhoneNumber = sellerEntity.PhoneNumber,
        };

    }

    public static List<SellerDTO> ToDtoList(IEnumerable<SellerEntity> sellerEntity)
    {
        return sellerEntity.Select(ToDto).ToList();
    }


    public static SellerEntity ToEntity(SellerDTO sellerDto)
    {
        if (sellerDto == null) return new SellerEntity(null);
        
        return new SellerEntity(sellerDto.PickupLocation)
        {
            Id = sellerDto.Id,
            Name = sellerDto.Name ,
            PhoneNumber = sellerDto.PhoneNumber,
        };
    }
    
    public static List<SellerEntity> ToEntitylist(List<SellerDTO> sellerDto)
    {
        return sellerDto.Select(ToEntity).ToList();
    }

}