using DDD_Practice.DDDPractice.Domain.Repositories;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerDTO> GetByIdAsync(Guid id)
    {
        var sellerEntity = await _sellerRepository.GetByIdAsync(id);
        return SellerMapper.ToDto(sellerEntity);
    }

    public async Task AddAsync(SellerDTO sellerDto)
    {
        var sellerEntity = SellerMapper.ToEntity(sellerDto);
        await _sellerRepository.AddAsync(sellerEntity);
    }

    public async Task UpdateAsync(SellerDTO sellerDto)
    { 
        var sellerEntity = SellerMapper.ToEntity(sellerDto);
        await _sellerRepository.UpdateAsync(sellerEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _sellerRepository.DeleteAsync(id);
    }

    public async Task<List<SellerDTO>> GetAllAsync()
    {
        var sellerList = await _sellerRepository.GetAllAsync();
        return SellerMapper.ToDtoList(sellerList);
    }
}