namespace Application.Handlers.Queries.DoorGroupQueryHandler;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.DoorGroupDtos;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Models.DoorGroupModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record GetAllDoorGroupHandler(IRepository Repository) : IGetAllQueryHandler<GetAllDoorGroupDto>
{
    public async Task<QResult<IEnumerable<GetAllDoorGroupDto>?>> Handle(GetAllQueryRequest<GetAllDoorGroupDto> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<DoorGroup, GetAllDoorGroupDto>()
        {
            SpecificationFunc = _ =>
             (request.GetAllParams.SearchValue is not null ? _.Where(_ => _.Name.ToLower().Contains(request.GetAllParams.SearchValue.ToLower())) :
             _)
             .Select(_ => new GetAllDoorGroupDto(_.Id, _.Name))
             .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        return await Repository.GetAllAsync(specs, cancellationToken);
    }
}
