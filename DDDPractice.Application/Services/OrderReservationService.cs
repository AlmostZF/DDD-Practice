using DDD_Practice.DDDPractice.Domain;
using DDD_Practice.DDDPractice.Domain.Entities;
using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.Service;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class OrderReservationService : IOrderReservationService
{

    private readonly IOrderReservationRepository _orderReservationRepository;
    private readonly IProductRepository _productRepository;
    private readonly IReservationFeeCalculate _calculate;
        
    public OrderReservationService(
        IOrderReservationRepository orderReservationRepository,
        IReservationFeeCalculate calculate,
        IProductRepository productRepository
    )
    {
        _orderReservationRepository = orderReservationRepository;
        _calculate = calculate;
        _productRepository = productRepository;
    }

    public async Task<List<OrderReservationResponseDTO>> GetBySecurityCodeAsync(string securityCode)
    {
        var listOrder= await _orderReservationRepository.GetBySecurityCodeAsync(securityCode);
        return OrderReservationMapper.ToDtoList(listOrder);
    }

    public async Task<OrderReservationResponseDTO> GetByIdAsync(Guid id)
    {
        var orderReservation = await CalculateTotalForOrderAsync(id);
        
        return OrderReservationMapper.ToDto(orderReservation);
    }

    public async Task UpdateStatusAsync(OrderReservationResponseDTO orderReservationResponseDto)
    {
        var orderReservation = await _orderReservationRepository.GetByIdAsync(orderReservationResponseDto.Id);
        if (orderReservation == null)
            throw new InvalidOperationException("Reserva não encontrada.");
        
        await _orderReservationRepository.UpdateStatusAsync(orderReservationResponseDto.OrderStatus,orderReservationResponseDto.Id);
    }
    
    public async Task UpdateAsync(OrderReservationUpdateDTO orderReservationUpdateDTO)
    {
        var orderReservation = await _orderReservationRepository.GetByIdAsync(orderReservationUpdateDTO.Id);
        if (orderReservation == null)
            throw new InvalidOperationException("Reserva não encontrada.");
        
        var (items, totalValue) = await BuildNewOrderItemsAsync(orderReservationUpdateDTO);

        var fee = _calculate.CalculateFeeCalculate(totalValue);
        
        if (!orderReservation.ListOrderItems.SequenceEqual(items))
            orderReservation.ListOrderItems = items;
        
        OrderReservationMapper.ToUpdateEntity(orderReservation, orderReservationUpdateDTO, items, fee, totalValue );
        
        // OrderReservationMapper.ToUpdateEntity(orderReservation,orderReservationUpdateDTO);
        await _orderReservationRepository.UpdateAsync(orderReservation);
    }

    public async Task DeleteAsync(Guid id)
    {
       await _orderReservationRepository.DeleteAsync(id);
    }

    public async Task AddAsync(OrderReservationCreateDTO orderReservationCreateDto)
    {
        var (items, totalValue) = await BuildOrderItemsAsync(orderReservationCreateDto);

        var fee = _calculate.CalculateFeeCalculate(totalValue);
        
        var orderReservationEntity = OrderReservationMapper.ToCreateEntity(orderReservationCreateDto,fee, totalValue);
        orderReservationEntity.ListOrderItems = items;
       
        await _orderReservationRepository.AddAsync(orderReservationEntity);
    }

    public async Task<List<OrderReservationResponseDTO>> GetByStatusAsync(StatusOrder status)
    {
        var orderReservationEntities = await _orderReservationRepository.GetByStatusAsync(status);
        return OrderReservationMapper.ToDtoList(orderReservationEntities);
    }

    public async Task<List<OrderReservationResponseDTO>> GetAllAsync()
    {
        var orderReservationEntities = await _orderReservationRepository.GetAllAsync();
        return OrderReservationMapper.ToDtoList(orderReservationEntities);
    }
    
    private async Task<(List<OrderReservationItemEntity> items, decimal total)> BuildOrderItemsAsync(
        OrderReservationCreateDTO itemDtos)
    {
        var items = new List<OrderReservationItemEntity>();
        var list = itemDtos.listOrderItens;
        decimal total = 0;

        foreach (var dto in list)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);
            if (product == null)
                throw new Exception($"Produto {dto.ProductId} não encontrado.");

            var unitPrice = product.UnitPrice;
            var totalPrice = unitPrice * dto.Quantity;
            
            total += totalPrice;
            items.Add(new OrderReservationItemEntity
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                SellerId = dto.SellerId,
                Quantity = dto.Quantity,
                UnitPrice = unitPrice,
                TotalPrice = totalPrice
            });
        }
        return (items, total);
    }

    private async Task<OrderReservationEntity> CalculateTotalForOrderAsync(
        Guid id)
    {
        var orderReservation = await _orderReservationRepository.GetByIdAsync(id);
        var list = orderReservation.ListOrderItems.ToList();
        
        decimal totalPrice = 0;
        
        foreach (var dto in list)
        { 
            totalPrice = dto.TotalPrice;
            
        }
        
        orderReservation.ValueTotal += totalPrice;
        return orderReservation;
    }
    
    private async Task<(ICollection<OrderReservationItemEntity> items, decimal total)> BuildNewOrderItemsAsync(
        OrderReservationUpdateDTO itemDtos)
    {
        var items = new List<OrderReservationItemEntity>();
        var list = itemDtos.listOrderItens;
        decimal total = 0;

        foreach (var dto in list)
        {
            var product = await _productRepository.GetByIdAsync(dto.ProductId);
            if (product == null)
                throw new Exception($"Produto {dto.ProductId} não encontrado.");

            var unitPrice = product.UnitPrice;
            var totalPrice = unitPrice * dto.Quantity;
            
            total += totalPrice;
            items.Add(new OrderReservationItemEntity
            {
                ProductId = dto.ProductId,
                SellerId = dto.SellerId,
                Quantity = dto.Quantity,
                UnitPrice = unitPrice,
                TotalPrice = totalPrice
            });
        }
        return (items, total);
    }
}