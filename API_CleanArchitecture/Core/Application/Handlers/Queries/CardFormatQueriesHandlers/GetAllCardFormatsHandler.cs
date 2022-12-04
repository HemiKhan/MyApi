namespace Application.Handlers.Queries.CardFormatQueriesHandlers;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Dtos.CardFormatDtos;

using MediatR;
using Application.Exceptions;
using Application.Specifications;
using Domain.Models.CardFormatsModels;
using Application.ExtensionMethods.Mappings.CardFormatMapping;
using Application.Common;
using Application.Specifications.Base;
using Microsoft.EntityFrameworkCore;

internal record GetAllCardFormatsHandler(IRepository repository, IQClaims claims) : IGetAllQueryHandler<GetAllCardFormatsDto>
{
    public async Task<QResult<IEnumerable<GetAllCardFormatsDto>?>> Handle(GetAllQueryRequest<GetAllCardFormatsDto> request, CancellationToken cancellationToken)
    {

        var specWithSearch = new GenericQSpec<CardFormat, GetAllCardFormatsDto>()
        {
            SpecificationFunc = _ => _.IgnoreQueryFilters()
            .Where(_ => _.OrganizationId == claims.OrganizationId /*|| _.OrganizationId == -1 */&& _.Name.Contains(request.GetAllParams.SearchValue!.ToLower()))
            .Select(_ => new GetAllCardFormatsDto { Id = _.Id, Name = _.Name })
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var spec = new GenericQSpec<CardFormat, GetAllCardFormatsDto>()
        {
            SpecificationFunc = _ => _.IgnoreQueryFilters()
            .Where(_ => _.OrganizationId == claims.OrganizationId /*|| _.OrganizationId == -1*/)
            .Select(_ => new GetAllCardFormatsDto { Id = _.Id, Name = _.Name })
            .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
        };
        var response = await repository.
            GetAllAsync(!string.IsNullOrEmpty(request.GetAllParams.SearchValue) ? specWithSearch : spec, cancellationToken, true, false);

        if (response.Status is Status.Exception)
            return response.Exception!;
        return QResults.From(response.Value);
    }
}
