namespace Application.Handlers.Queries.ControllerQueriesHanlders;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.ControllerDTOs;
using Domain.Models.ControllerModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record GetDoorByControllerIdHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<long, GetDoorByControllerIdDTO>
{
    public async Task<QResult<GetDoorByControllerIdDTO?>> Handle(QueryRequest<long, GetDoorByControllerIdDTO> request, CancellationToken cancellationToken)
    {
        var getDoorByControllerSpec = new GenericQSpec<Controller, GetDoorByControllerIdDTO>()
        {
            SpecificationFunc = _ => _.IgnoreQueryFilters().Include(_ => _.Doors).Where(_=>_.Id == request.Request)
            .Select(_ => new GetDoorByControllerIdDTO()
            {
                Id = _.Id,
                Doors = _.Doors.Select(_ => new DoorListByControllerId
                {
                    DoorId = _.Id,
                    Name = _.Name
                })
            })
        };
        var getAllControllerResult = await Repository.FirstOrDefaultAsync(getDoorByControllerSpec, cancellationToken);
        if (getAllControllerResult.Status is Status.Exception)
            return getAllControllerResult.Exception!;

        return getAllControllerResult;
    }
}
