namespace Application.Interfaces.Services;

using Application.Handlers;
using Domain.Dtos.OutputSensorDTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOutputSensorService
{
    Task<ApiResponse> AddUpdateControllerIoPortsAsync(IEnumerable<Update_ControllerIoPorts_Dto> dto, CancellationToken cancellationToken);
    Task<ApiResponse> GetAllControllersAsync(GetAllParams @params, CancellationToken cancellationToken);
    Task<ApiResponse> GetDefaultIOPorts(long ControllerId, CancellationToken cancellationToken);
}
