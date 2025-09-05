using DDD_Practice.DDDPractice.Domain.Enums;
using DDD_Practice.DDDPractice.Domain.ValueObjects;
using DDDPractice.Application.DTOs;
using DDDPractice.Application.DTOs.Request.ProductCreateDTO;

namespace DDDPractice.Application.Interfaces;

public interface IOrderReservationService
{
    Task<List<OrderReservationResponseDTO>> GetBySecurityCodeAsync(string securityCode);
    Task<OrderReservationResponseDTO> GetByIdAsync(Guid id);
    Task UpdateStatusAsync(OrderReservationResponseDTO orderReservationResponseDto);
    Task UpdateAsync(OrderReservationUpdateDTO orderReservationUpdateDto);
    Task DeleteAsync(Guid id);
    Task AddAsync(OrderReservationCreateDTO order);
    Task<List<OrderReservationResponseDTO>> GetByStatusAsync(StatusOrder status);
    Task<List<OrderReservationResponseDTO>> GetAllAsync();
}