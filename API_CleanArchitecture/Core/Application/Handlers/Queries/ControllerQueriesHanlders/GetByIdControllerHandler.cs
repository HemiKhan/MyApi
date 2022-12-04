namespace Application.Handlers.Queries.ControllerQueriesHanlders;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.ControllerDTOs;
using Domain.Models.ControllerModels;
using System.Threading.Tasks;

internal record GetByIdControllerHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<long, GetControllerByIdDTO>
{
    public async Task<QResult<GetControllerByIdDTO?>> Handle(QueryRequest<long, GetControllerByIdDTO> request, CancellationToken cancellationToken)
    {
        var getAllSpec = new GenericQSpec<Controller, GetControllerByIdDTO>()
        {
            SpecificationFunc = _ => _.Where(request.Request)
            .Select(_ => new GetControllerByIdDTO()
            {
                Id = _.Id,
                Name = _.Name,
                IsOneDoor = _.IsOneDoor,
                MACAddress = _.MACAddress,
                OAK = _.OAK,
                UserName = _.UserName,
                IsDoor1Added = _.IsDoor1Added,
                IsDoor2Added = _.IsDoor2Added,
                State = _.State.ToString(),
                Status = _.Status,
                Model = _.Model.ToString()
            })
        };
        var getAllControllerResult = await Repository.FirstOrDefaultAsync(getAllSpec, cancellationToken);
        if (getAllControllerResult.Status is Status.Exception)
            return getAllControllerResult.Exception!;

        return getAllControllerResult;
    }

}
