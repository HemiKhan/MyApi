namespace Application.Interfaces.Services.DoorServices;
using Application.Handlers;

using Domain.Dtos;
using Domain.Dtos.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDoorService  
{
    Task<ApiResponse> AddAsync(Door_Add_DTO addDoorDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(Door_GetById_DTO updateDoorDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(DeleteDoorDTO deleteDoorDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = new());
}
