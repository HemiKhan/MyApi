namespace Application.Interfaces.Services.ScheduleServices;

using Application.Handlers;
using Domain.Dtos;

public interface IScheduleService
{
    Task<ApiResponse> AddAsync(AddScheduleDTO addScheduleDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(UpdateScheduleDTO updateDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(DeleteScheduleDTO dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken);
    Task<ApiResponse> GetAllScheduleAsync(GetAllParams getAllParams, CancellationToken cancellationToken);
    //Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = new());
}
