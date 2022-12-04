namespace Application.Interfaces.Services;

using Application.Handlers;
using Domain.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAreaService
{
    Task<ApiResponse> AddAsync(AddAreaDto dto, CancellationToken cancellationToken);
    Task<ApiResponse> UpdateAsync(UpdateAreaDto dto, CancellationToken cancellationToken);
    Task<ApiResponse> GetById(long Id, CancellationToken cancellationToken);
    Task<ApiResponse> DeleteAsync(long Id, CancellationToken cancellationToken);
    Task<ApiResponse> GetAllAsync(GetAllParams @params, CancellationToken cancellationToken);
}
