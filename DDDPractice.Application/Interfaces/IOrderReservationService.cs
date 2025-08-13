using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface IOrderReservationService
{
    Task<List<OrderReservationDTO>> GetBySecurityCodeAsync(SecurityCode securityCode);
    Task<OrderReservationDTO> GetByIdAsync(Guid id);
    Task UpdateStatusAsync(OrderReservationDTO status, Guid id);
    Task UpdateAsync(OrderReservationDTO order);
    Task DeleteAsync(Guid id);
    Task AddAsync(OrderReservationDTO order);
    Task<List<OrderReservationDTO>> GetByStatusAsync(StatusOrder status);
    Task<List<OrderReservationDTO>> GetAllAsync();
}