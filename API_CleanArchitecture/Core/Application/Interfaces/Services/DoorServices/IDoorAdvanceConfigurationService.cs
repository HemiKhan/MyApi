namespace Application.Interfaces.Services.DoorServices;
using Application.Handlers;

using Domain.Dtos.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDoorAdvanceConfigurationService
{
    Task<ApiResponse> AddAsync(AddDoorAdvanceConfgDTO addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(UpdateDoorAdvanceConfgDTO addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(DeleteDoorAdvanceConfgDTO delete_ControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = new());
}
