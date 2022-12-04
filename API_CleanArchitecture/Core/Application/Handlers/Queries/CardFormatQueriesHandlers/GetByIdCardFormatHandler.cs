namespace Application.Handlers.Queries.CardFormatQueriesHandlers;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.CardFormatDtos;
using Domain.Models.CardFormatsModels;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

internal record GetByIdCardFormatHandler(IRepository repository) : IQueryHandler<long, GetByIdCardFormatDto>
{
    public async Task<QResult<GetByIdCardFormatDto?>> Handle(QueryRequest<long, GetByIdCardFormatDto> request, CancellationToken cancellationToken)
    {
        var spec = new GenericQSpec<CardFormat, GetByIdCardFormatDto>()
        {
            SpecificationFunc = _ => _.Where(request.Request).Include(_ => _.CardFormatItems)
            .Select(_ =>
            new GetByIdCardFormatDto
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                BitLength = _.BitLength,
                IsEnable = _.IsEnable,
                CardFormatItems = _.CardFormatItems.Select(_ => new GetFormatItems { Id = _.Id, FieldMapName = _.Name, EncodingRange = _.EncodingRange, Encoding = _.Encoding })
            })
        };
        return await repository.FirstOrDefaultAsync(spec, cancellationToken, true, false);
    }
}
