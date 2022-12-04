namespace Infrastructure.Services.PrioritiesServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.PrioritiesServices;
using Domain.Dtos.PrioritiesDTOs;
using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record PrioritiesServices(IQSender Sender) : IPrioritiesServices
{
    public async Task<ApiResponse> AddAsync(AddPriorityDTO addPriorityDTO, CancellationToken cancellationToken = new())
    {
        var response = await Sender.Send(new CommandRequest<AddPriorityDTO>(addPriorityDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeletePriorityDTO addPriorityDTO, CancellationToken cancellationToken = new())
    {
        var response = await Sender.Send(new CommandRequest<DeletePriorityDTO>(addPriorityDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new())
    {
        var response = await Sender.Send(new QueryRequest<long, GetByIdPrioritiesDTO>(Id), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetAll(GetAllParams getAllParams, CancellationToken cancellationToken = new())
    {
        var response = await Sender.Send(new GetAllQueryRequest<GetAllPrioritiesDTOScroll>(getAllParams));
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(Update_PriorityDTO addPriorityDTO, CancellationToken cancellationToken = new())
    {
        var response = await Sender.Send(new CommandRequest<Update_PriorityDTO>(addPriorityDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }
}
