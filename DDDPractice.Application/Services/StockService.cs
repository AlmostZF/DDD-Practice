using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;
    private readonly IProductRepository _productRepository;

    public StockService(IStockRepository stockRepository, IProductRepository productRepository)
    {
        _stockRepository = stockRepository;
        _productRepository = productRepository;
    }
 
    public async Task<List<StockResponseDTO>> GetAllAsync()
    {
        var stockList = await _stockRepository.GetAllAsync();
        return StockMapper.ToDtoList(stockList);
    }

    public async Task<StockResponseDTO> GetByIdAsync(Guid productId)
    {
        var stock = await _stockRepository.GetByIdAsync(productId);

        if (stock == null)
            throw new Exception("Erro ao buscar produto ");

        stock.Total = StockMoney.CalculateTotal(stock.Product.UnitPrice, stock.Quantity).Amount;
        var stockDto = StockMapper.ToDto(stock);

        return stockDto;
    }

    public async Task UpdateQuantityAsync(StockUpdateDTO stockUpdateDto)
    {
        var stock = await _stockRepository.GetByIdAsync(stockUpdateDto.Id);
        if (stock == null)
            throw new Exception("Stock not found.");
    
        StockMapper.ToUpdateEntity(stock,stockUpdateDto);
        await _stockRepository.UpdateQuantityAsync(stock);
    }

    public async Task AddAsync(StockCreateDTO stockCreateDto)
    {
        var stockEntityWithProduct = await _stockRepository.GetByProductIdAsync(stockCreateDto.ProductId);
        if (stockEntityWithProduct != null )
            throw new Exception("Stock already had product.");
    
        var productEntity = await _productRepository.GetByIdAsync(stockCreateDto.ProductId);
        if (productEntity == null)
            throw new Exception("Product not found.");

        var stockEntity = StockMapper.ToCreateEntity(stockCreateDto, productEntity.UnitPrice);
        await _stockRepository.AddAsync(stockEntity);
    }
    
}