namespace Infrastructure.Services;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Exceptions;
using Domain.Models.OutputSensorModel;

using AutoWrapper.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record OutputSensorService(IQSender QSender) : IOutputSensorService
{
    public async Task<ApiResponse> GetAllControllersAsync(GetAllParams @params, CancellationToken cancellationToken)
    {
        var result = await QSender.Send(new GetAllQueryRequest<GetAll_Controllers_Dto>(@params));
        if (result.Status is Application.Common.Status.Exception)
            throw result.Exception!;
        return result.Result!;
    }

    public async Task<ApiResponse> AddUpdateControllerIoPortsAsync(IEnumerable<Update_ControllerIoPorts_Dto> dto, CancellationToken cancellationToken)
    {
        CheckNameNotDuplicateInList(dto);
        var qsenderReuslt = await QSender.Send(new CommandRequest<IEnumerable<Update_ControllerIoPorts_Dto>>(dto));
        if (qsenderReuslt.Status is Status.Exception)
            throw qsenderReuslt.Exception!;
        return qsenderReuslt.Result!;
    }

    private void CheckNameNotDuplicateInList(IEnumerable<Update_ControllerIoPorts_Dto> dto)
    {
        if (dto.Count() < 6)
            throw new QException("Cannot create less than six record!");
        if (dto.Select(x => x.Name).Distinct().Count() != dto.Count())
        {
            throw new QException("Please add unique name!");
        }
    }

    public async Task<ApiResponse> GetDefaultIOPorts(long ControllerId, CancellationToken cancellationToken)
    {
        var controllerIsExist = await QSender.Send(new QueryRequest<long, bool>(ControllerId));
        if (controllerIsExist.Status is Status.Exception)
            throw controllerIsExist.Exception!;

        var qsenderResult = await QSender.Send(new QueryRequest<long, IEnumerable<IOModel>>(ControllerId));
        if (qsenderResult.Status is Application.Common.Status.Exception)
            throw qsenderResult.Exception!;
        return qsenderResult.Result!;
    }
}
