namespace Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.Door;
using Domain.Models.CardFormatsModels;
using Domain.Models.ControllerModels.DoorModels;

using Microsoft.EntityFrameworkCore;

public record GetAllDoorsHandler(IRepository Repository, IQClaims claims) : IGetAllQueryHandler<GetAllDoorsDTO>
{
    public async Task<QResult<IEnumerable<GetAllDoorsDTO>?>> Handle(GetAllQueryRequest<GetAllDoorsDTO> request, CancellationToken cancellationToken)
    {
        var spec = new GenericQSpec<Door, GetAllDoorsDTO>()
        {
            SpecificationFunc = _ => _.OrderBy(_ => _.Name).Select(_ => new GetAllDoorsDTO(_.Id, _.Name))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var specWithSearch = new GenericQSpec<Door, GetAllDoorsDTO>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Name.ToLower().Contains(request.GetAllParams.SearchValue!.ToLower())).OrderBy(p => p.Name)
            .Select(_ => new GetAllDoorsDTO(_.Id, _.Name))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var response = await Repository.
            GetAllAsync(!string.IsNullOrEmpty(request.GetAllParams.SearchValue) ? specWithSearch : spec, cancellationToken, true, false);

        if (response.Status is Status.Exception)
            return response.Exception!;
        return response;
    }
}
