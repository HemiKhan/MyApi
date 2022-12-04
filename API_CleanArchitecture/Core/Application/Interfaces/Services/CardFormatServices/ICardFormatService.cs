namespace Application.Interfaces.Services.CardFormatServices;

using Application.Handlers;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.ControllerDTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICardFormatService
{
    Task<ApiResponse> AddAsync(AddCardFormatDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(UpdateCardFormatDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(DeleteCardFormatDto dto, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllScrollAsync(GetAllParams param, CancellationToken cancellationToken = new());
    Task<ApiResponse> FirstOrDefaultAsync(long Id, CancellationToken cancellationToken = new());
}
