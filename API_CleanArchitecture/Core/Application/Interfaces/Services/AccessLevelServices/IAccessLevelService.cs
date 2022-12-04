namespace Application.Interfaces.Services.AccessLevelServices;

using Application.Handlers;
using Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccessLevelService 
{
    Task<ApiResponse> AddAsync(Add_AccessLevel_DTO dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(Update_AccessLevel_DTO dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(Delete_AccessLevel_DTO dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetByIdAsync(long Id, CancellationToken cancellationToken = new());

}
