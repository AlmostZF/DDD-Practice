using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
 
    public async Task<List<StockDTO>> GetAllAsync()
    {
        var productList = await _stockRepository.GetAllAsync();
        return StockMapper.ToDtoList(productList);
    }

    public async Task<StockDTO> GetByProductIdAsync(Guid productId)
    {
        var stock = await _stockRepository.GetByProductIdAsync(productId);

        if (stock == null)
            throw new Exception("Erro ao buscar produto ");


        var stockDTO = StockMapper.ToDto(stock);

        return stockDTO;
    }

    public async Task UpdateQuantityAsync(Guid productId, int newQuantity)
    {
        await _stockRepository.UpdateQuantityAsync(productId, newQuantity);
    }

    public async Task AddAsync(StockDTO stockDto)
    {
        var stockEntity = StockMapper.ToEntity(stockDto);
        await _stockRepository.AddAsync(stockEntity);
    }
}