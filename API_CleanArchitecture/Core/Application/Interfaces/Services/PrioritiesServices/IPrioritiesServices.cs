namespace Application.Interfaces.Services.PrioritiesServices;

using Application.Handlers;
using Domain.Dtos.PrioritiesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPrioritiesServices
{
    Task<ApiResponse> AddAsync(AddPriorityDTO addPriorityDTO, CancellationToken cancellationToken = new()); 
    Task<ApiResponse> UpdateAsync(Update_PriorityDTO addPriorityDTO, CancellationToken cancellationToken = new()); 
    Task<ApiResponse> DeleteAsync(DeletePriorityDTO addPriorityDTO, CancellationToken cancellationToken = new()); 
    Task<ApiResponse> GetAll(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new());
}
