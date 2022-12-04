namespace Application.Handlers.Queries.AreaQueriesHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Models;
using Domain.Models.CardFormatsModels;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record GetAllAreaHandler(IRepository repo) : IGetAllQueryHandler<GetAllAreasDto>
{
    public async Task<QResult<IEnumerable<GetAllAreasDto>?>> Handle(GetAllQueryRequest<GetAllAreasDto> request, CancellationToken cancellationToken)
    {
        var specWithSearch = new GenericQSpec<Area, GetAllAreasDto>()
        {
            SpecificationFunc = _ => _
            .Where(_ => _.Name.ToLower().Contains(request.GetAllParams.SearchValue!.ToLower()))
            .Select(_ => new GetAllAreasDto(_.Id, _.Name, _.IsEntrance))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var spec = new GenericQSpec<Area, GetAllAreasDto>()
        {
            SpecificationFunc = _ => _.Select(_ => new GetAllAreasDto(_.Id, _.Name, _.IsEntrance))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var response = await repo.
            GetAllAsync(!string.IsNullOrEmpty(request.GetAllParams.SearchValue) ? specWithSearch : spec, cancellationToken, true, false);

        if (response.Status is Status.Exception)
            return response.Exception!;
        return QResults.From(response.Value);
    }
}
