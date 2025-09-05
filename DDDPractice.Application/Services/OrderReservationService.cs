using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.Service;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class OrderReservationService : IOrderReservationService
{

    private readonly IOrderReservationRepository _orderReservationRepository;
    private readonly IReservationFeeCalculate _calculate;
        
    public OrderReservationService(
        IOrderReservationRepository orderReservationRepository,
        IReservationFeeCalculate calculate
    )
    {
        _orderReservationRepository = orderReservationRepository;
        _calculate = calculate;
    }

    public async Task<List<OrderReservationResponseDTO>> GetBySecurityCodeAsync(string securityCode)
    {
        var listOrder= await _orderReservationRepository.GetBySecurityCodeAsync(securityCode);
        return OrderReservationMapper.ToDtoList(listOrder);
    }

    public async Task<OrderReservationResponseDTO> GetByIdAsync(Guid id)
    {
        var orderReservation = await _orderReservationRepository.GetByIdAsync(id);
        var list = orderReservation.ListOrderItems.ToList();

        for (var i = 0; i < list.Count(); i++)
        {
            var item = list[i];
            orderReservation.ValueTotal += item.TotalPrice;
        }
        
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
        
        OrderReservationMapper.ToUpdateEntity(orderReservation,orderReservationUpdateDTO);
        await _orderReservationRepository.UpdateAsync(orderReservation);
    }

    public async Task DeleteAsync(Guid id)
    {
       await _orderReservationRepository.DeleteAsync(id);
    }

    public async Task AddAsync(OrderReservationCreateDTO orderReservationCreateDto)
    {
        var list = orderReservationCreateDto.listOrderItens.ToList();
        decimal? totalValue = 0;
        for (var i = 0; i < list.Count(); i++)
        {
            var item = list[i];
            item.TotalPrice = item.Quantity * item.UnitPrice;
            totalValue += item.TotalPrice;
        }
        
        var orderReservationEntity = OrderReservationMapper.ToCreateEntity(orderReservationCreateDto, _calculate.CalculateFeeCalculate(totalValue??0), totalValue??0);
       
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
}