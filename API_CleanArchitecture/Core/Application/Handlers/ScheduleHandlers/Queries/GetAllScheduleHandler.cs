namespace Application.Handlers.ScheduleHandlers.Queries;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Dtos.ControllerDTOs;

using MediatR;

using Newtonsoft.Json;

public record GetAllScheduleHandler(IRepository Repository, IDapperRepository _dapperRepo, IQClaims claims) : IGetAllQueryHandler<Get_ScheduleDTO>
{

    async Task<QResult<IEnumerable<Get_ScheduleDTO>?>> IRequestHandler<GetAllQueryRequest<Get_ScheduleDTO>, QResult<IEnumerable<Get_ScheduleDTO>?>>.Handle(GetAllQueryRequest<Get_ScheduleDTO> request, CancellationToken cancellationToken)
    {
        var getall_Scroll_Specs = new GenericDSpec<string>
        {
            CommandText = @"qn_Schedule_ScrollList",
            Parameters = new { SearchValue = request.GetAllParams.SearchValue, PageNumber = request.GetAllParams.PageIndex ?? 1, PageSize = request.GetAllParams.PageSize ?? 50, OrganizationId = claims.OrganizationId }
        };
        var dbJsonResult = await _dapperRepo.ExecuteScalarAsync(getall_Scroll_Specs, false, cancellationToken);
        if (dbJsonResult.Status is Status.Exception)
            return dbJsonResult.Exception!;
        if (dbJsonResult.Status is Status.NotFound)
            return new QException("Record.NotFound");

        var result = JsonConvert.DeserializeObject<IEnumerable<Get_ScheduleDTO>?>(dbJsonResult.Value!);
        return QResults.From(result);
    }
}