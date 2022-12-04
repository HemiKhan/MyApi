namespace Application.Handlers.Queries.OutputSensorHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Models.ControllerModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



internal record GetAllControllersHandler(IRepository Repository) : IGetAllQueryHandler<GetAll_Controllers_Dto>
{
    public async Task<QResult<IEnumerable<GetAll_Controllers_Dto>?>> Handle(GetAllQueryRequest<GetAll_Controllers_Dto> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<Controller, GetAll_Controllers_Dto>()
        {
            SpecificationFunc = _ =>
            (request.GetAllParams.SearchValue is not null ? _.Where(_ => _.Name.ToLower().Contains(request.GetAllParams.SearchValue.ToLower())) :
            _)
            .Select(_ => new GetAll_Controllers_Dto(_.Id, _.Name))
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        return await Repository.GetAllAsync(specs, cancellationToken, true, false);
    }
}
