namespace Application.Interfaces.Services.ScheduleServices;

using Domain.Dtos.Schedule.ScheduleItemsDtos;

public interface IScheduleItemService
{
    Task<ApiResponse> AddScheduleItemsAsync(AddScheduleItemDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateScheduleItemsAsync(UpdateScheduleItemDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteItemAsync(DeleteScheduleItemDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetItemByIdAsync(GetScheduleItemByIdDTO dto, CancellationToken cancellationToken = new());
}
