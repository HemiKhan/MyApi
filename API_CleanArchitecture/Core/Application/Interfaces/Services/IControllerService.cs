namespace Application.Interfaces.Services;
using Application.Handlers;
using Domain.Dtos.ControllerDTOs;

public interface IControllerService
{
    Task<ApiResponse> AddAsync(AddControllerCommand addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(Update_ControllerDTO addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(Delete_ControllerDTO delete_ControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetDoorByControllerIdAsync(long id, CancellationToken cancellationToken = new());
}
