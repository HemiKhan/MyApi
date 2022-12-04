namespace Application.Handlers.PrioritiesHandler.Queries;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.PrioritiesDTOs;

public record GetAllPriorityHandler(IRepository Repository, IQClaims claims) : IGetAllQueryHandler<GetAllPrioritiesDTOScroll>
{

    //public async Task<QResult<IEnumerable<GetAllPrioritiesDTO>?>> Handle(GetAllQueryRequest<GetAllPrioritiesDTO> request, CancellationToken cancellationToken)
    //{
    //    var Specs = new GetAllSpec<Priorities, GetAllPrioritiesDTO>()
    //    {
    //        SearchValue = request.GetAllParams.SearchValue,
    //        PageNumber = request.GetAllParams.PageIndex,
    //        PageSize = request.GetAllParams.PageSize,
    //        SearchExpression = _ => _.Name!.ToLower().Contains(request.GetAllParams.SearchValue!.ToLower()),
    //        SelectExpression = _ => new(_.Id, _.Name!, _.PriortyLevel, _.ColorCode!)
    //    };
    //    var response = await Repository.GetAllAsync(Specs, cancellationToken);
    //    if (response.Status is Status.Exception)
    //        return response.Exception!;
    //    //if(response.Value is null)
    //    //    return new QException
    //    return QResults.From( response.Value);

    //}

    public async Task<QResult<IEnumerable<GetAllPrioritiesDTOScroll>?>> Handle(GetAllQueryRequest<GetAllPrioritiesDTOScroll> request, CancellationToken cancellationToken)
    {
        
        var response = await Repository.
            GetAllAsync(Specs.PrioritiesSpecs.GetAllPrioritiesSpecs
            (request.GetAllParams, claims.OrganizationId), cancellationToken, false, false);

        if (response.Status is Status.Exception)
            return response.Exception!;
        if (response.Value is null)
            return HandlerExceptions.PrioritiesHandlerException.NoPriorityExists;
        return QResults.From(response.Value);
    }
}
