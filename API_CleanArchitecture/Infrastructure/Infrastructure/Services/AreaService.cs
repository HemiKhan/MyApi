namespace Infrastructure.Services;

using Application.Common;
using Application.Handlers;
using Application.Interfaces.Services;
using Domain.Dtos;

using AutoWrapper.Wrappers;

using Humanizer;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AreaService(ISender sender) : IAreaService
{
    async Task<ApiResponse> IAreaService.AddAsync(AddAreaDto dto, CancellationToken cancellationToken)
    {
        var senderResult = await sender.Send(new CommandRequest<AddAreaDto>(dto), cancellationToken);
        if (senderResult.Status is Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    async Task<ApiResponse> IAreaService.DeleteAsync(long Id, CancellationToken cancellationToken)
    {
        var senderResult = await sender.Send(new CommandRequest<long>(Id), cancellationToken);
        if (senderResult.Status is Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    async Task<ApiResponse> IAreaService.GetById(long Id, CancellationToken cancellationToken)
    {
        var senderResult = await sender.Send(new QueryRequest<long, GetAreaByIdDto>(Id), cancellationToken);
        if (senderResult.Status is Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }

    async Task<ApiResponse> IAreaService.UpdateAsync(UpdateAreaDto dto, CancellationToken cancellationToken)
    {
        var senderResult = await sender.Send(new CommandRequest<UpdateAreaDto>(dto), cancellationToken);
        if (senderResult.Status is Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }
    async Task<ApiResponse> IAreaService.GetAllAsync(GetAllParams @params, CancellationToken cancellationToken)
    {
        var senderResult = await sender.Send(new GetAllQueryRequest<GetAllAreasDto>(@params), cancellationToken);
        if (senderResult.Status is Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }
}
