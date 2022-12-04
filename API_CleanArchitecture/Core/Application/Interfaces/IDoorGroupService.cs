namespace Application.Interfaces;

using Application.Handlers;
using Domain.Dtos.DoorGroupDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDoorGroupService
{
    Task<ApiResponse> AddAsync(AddDoorGroupDto Dto, CancellationToken cancellationToken);
    Task<ApiResponse> UpdateAsync(UpdateDoorGroupDto Dto, CancellationToken cancellationToken);
    Task<ApiResponse> GetAllAsync(GetAllParams @params, CancellationToken cancellationToken);
    Task<ApiResponse> GetByIdAsync(long Id, CancellationToken cancellationToken);
    Task<ApiResponse> DeleteAsync(long Id, CancellationToken cancellationToken);
}
