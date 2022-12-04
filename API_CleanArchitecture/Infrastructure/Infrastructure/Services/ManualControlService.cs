namespace Infrastructure.Services;

using Application.Handlers;
using Application.Interfaces;
using Domain.Dtos.ManualControlDtos;

using AutoWrapper.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record ManualControlService(IQSender Sender) : IManualControlService
{
    public Task<ApiResponse> AddManualControl(AddManualControlDto Dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> GetDoorDetals(long Id, CancellationToken cancellationToken)
    {
        var senderResult = await Sender.Send(new QueryRequest<long, GetDoorDetailsByIdDtoForManualControl>(Id));
        if (senderResult.Status is Application.Common.Status.Exception)
            throw senderResult.Exception!;
        return senderResult.Result!;
    }
}
