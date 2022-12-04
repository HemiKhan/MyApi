namespace Infrastructure.Services.AccesslevelServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.AccessLevelServices;
using Domain.Dtos.AccessLevelDTOs;
using AutoWrapper.Wrappers;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AccessLevelService(IQSender Sender) : IAccessLevelService
{
    public async Task<ApiResponse> AddAsync(Add_AccessLevel_DTO dto, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<Add_AccessLevel_DTO>(dto),cancellationToken);
        if (response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(Delete_AccessLevel_DTO dto, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<Delete_AccessLevel_DTO>(dto), cancellationToken);
        if (response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new GetAllQueryRequest<GetAll_AccessLevel_DTO>(getAllParams), cancellationToken);
        if (response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetByIdAsync(long Id, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new QueryRequest<long,GetById_AccessLevel_DTO>(Id), cancellationToken);
        if (response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;

    }

    public async Task<ApiResponse> UpdateAsync(Update_AccessLevel_DTO dto, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<Update_AccessLevel_DTO>(dto), cancellationToken);
        if (response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;

    }
}
