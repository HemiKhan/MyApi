namespace Application.Handlers.ScheduleHandlers.Queries;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Models.CardFormatsModels;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record GetAllScheduleIdNameHandler(IRepository repo, IQClaims claims) : IGetAllQueryHandler<GetScheduleDTO>
{
    public async Task<QResult<IEnumerable<GetScheduleDTO>?>> Handle(GetAllQueryRequest<GetScheduleDTO> request, CancellationToken cancellationToken)
    {
        var specWithSearch = new GenericQSpec<Schedule, GetScheduleDTO>()
        {
            SpecificationFunc = _ => _.IgnoreQueryFilters()
            .Where(_ => _.OrganizationId == claims.OrganizationId || _.OrganizationId == -1 && _.Name.Contains(request.GetAllParams.SearchValue!.ToLower()))
            .Select(_ => new GetScheduleDTO(_.Id, _.Name))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var spec = new GenericQSpec<Schedule, GetScheduleDTO>()
        {
            SpecificationFunc = _ => _.IgnoreQueryFilters()
            .Where(_ => _.OrganizationId == claims.OrganizationId || _.OrganizationId == -1)
            .Select(_ => new GetScheduleDTO(_.Id, _.Name))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        return await repo.
            GetAllAsync(!string.IsNullOrEmpty(request.GetAllParams.SearchValue) ? specWithSearch : spec, cancellationToken, true, false);

    }
}
