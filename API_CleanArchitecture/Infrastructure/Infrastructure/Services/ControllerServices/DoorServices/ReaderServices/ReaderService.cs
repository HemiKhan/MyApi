namespace Infrastructure.Services.ReaderServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.ReaderServices;
using Domain.Dtos.ReaderDTOs;
using AutoWrapper.Wrappers;
using System.Threading;
using System.Threading.Tasks;

public record ReaderService(IQSender Sender) : IReaderService
{
    public async Task<ApiResponse> AddAsync(AddReaderDTO addReaderDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<AddReaderDTO>(addReaderDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeleteReaderDTO deleteReaderDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<DeleteReaderDTO>(deleteReaderDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new GetAllQueryRequest<Reader_GetById_DTO>(getAllParams), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new QueryRequest<long, Reader_GetById_DTO>(id), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(UpdateReaderDTO updateReaderDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<UpdateReaderDTO>(updateReaderDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }
}
