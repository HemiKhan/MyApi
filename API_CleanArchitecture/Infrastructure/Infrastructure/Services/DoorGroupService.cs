namespace Infrastructure.Services;

using Application.Handlers;
using Application.Interfaces;
using Domain.Dtos.DoorGroupDtos;

using AutoWrapper.Wrappers;

using Humanizer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record DoorGroupService(IQSender _sender) : IDoorGroupService
{
    public async Task<ApiResponse> AddAsync(AddDoorGroupDto Dto, CancellationToken cancellationToken)
    {
        var senderResult = await _sender.Send(new CommandRequest<AddDoorGroupDto>(Dto), cancellationToken);
        if (senderResult.Status is Application.Common.Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(long Id, CancellationToken cancellationToken)
    {
        var senderResult = await _sender.Send(new CommandRequest<long, long>(Id), cancellationToken);
        if (senderResult.Status is Application.Common.Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams @params, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAllQueryRequest<GetAllDoorGroupDto>(@params), cancellationToken);
        if (result.Status is Application.Common.Status.Exception)
            throw result.Exception!;
        return result.Result!;
    }

    public async Task<ApiResponse> GetByIdAsync(long Id, CancellationToken cancellationToken)
    {
        var senderResult = await _sender.Send(new QueryRequest<long, GetByIdDoorGroupDto>(Id), cancellationToken);
        if (senderResult.Status is Application.Common.Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(UpdateDoorGroupDto Dto, CancellationToken cancellationToken)
    {
        var senderResult = await _sender.Send(new CommandRequest<UpdateDoorGroupDto>(Dto), cancellationToken);
        if (senderResult.Status is Application.Common.Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }
}
