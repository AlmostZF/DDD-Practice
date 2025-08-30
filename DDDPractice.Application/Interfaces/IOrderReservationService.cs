using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;

namespace DDDPractice.Application.Interfaces;

public interface IOrderReservationService
{
    Task<List<OrderReservationResponseDTO>> GetBySecurityCodeAsync(SecurityCode securityCode);
    Task<OrderReservationResponseDTO> GetByIdAsync(Guid id);
    Task UpdateStatusAsync(OrderReservationResponseDTO status, Guid id);
    Task UpdateAsync(OrderReservationResponseDTO order);
    Task DeleteAsync(Guid id);
    Task AddAsync(OrderReservationResponseDTO order);
    Task<List<OrderReservationResponseDTO>> GetByStatusAsync(StatusOrder status);
    Task<List<OrderReservationResponseDTO>> GetAllAsync();
}