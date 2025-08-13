using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.Repositories;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.Interfaces;
using DDDPractice.Application.Mappers;

namespace DDDPractice.Application.Services;

public class OrderReservationService : IOrderReservationService
{

    private readonly IOrderReservationRepository _orderReservationRepository;

    public OrderReservationService(IOrderReservationRepository orderReservationRepository)
    {
        _orderReservationRepository = orderReservationRepository;
    }

    public async Task<List<OrderReservationDTO>> GetBySecurityCodeAsync(SecurityCode securityCode)
    {
        var listOrder= await _orderReservationRepository.GetBySecurityCodeAsync(securityCode);
        return OrderReservationMapper.ToDtoList(listOrder);
    }

    public async Task<OrderReservationDTO> GetByIdAsync(Guid id)
    {
        var orderReservation = await _orderReservationRepository.GetByIdAsync(id);
        return OrderReservationMapper.ToDto(orderReservation);
    }

    public async Task UpdateStatusAsync(OrderReservationDTO orderReservationDto, Guid id)
    {
       await _orderReservationRepository.UpdateStatusAsync(orderReservationDto.OrderStatus, id);
    }

    public async Task UpdateAsync(OrderReservationDTO orderReservationDto)
    {
        var orderReservationEntity = OrderReservationMapper.ToEntity(orderReservationDto);
        await _orderReservationRepository.UpdateAsync(orderReservationEntity);
    }

    public async Task DeleteAsync(Guid id)
    {
       await _orderReservationRepository.DeleteAsync(id);
    }

    public async Task AddAsync(OrderReservationDTO orderReservationDto)
    {
        var orderReservationEntity = OrderReservationMapper.ToEntity(orderReservationDto);
        await _orderReservationRepository.AddAsync(orderReservationEntity);
    }

    public async Task<List<OrderReservationDTO>> GetByStatusAsync(StatusOrder status)
    {
        var orderReservationEntities = await _orderReservationRepository.GetByStatusAsync(status);
        return OrderReservationMapper.ToDtoList(orderReservationEntities);
    }

    public async Task<List<OrderReservationDTO>> GetAllAsync()
    {
        var orderReservationEntities = await _orderReservationRepository.GetAllAsync();
        return OrderReservationMapper.ToDtoList(orderReservationEntities);
    }
}