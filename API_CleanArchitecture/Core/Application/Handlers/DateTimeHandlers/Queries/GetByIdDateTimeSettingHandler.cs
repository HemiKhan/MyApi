namespace Application.Handlers.ControllerDateTimeSettingHandlers.Queries;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.ExtensionMethods.Mappings.ControllerDateTimeSettingMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.TimeZoneModels;

public record GetByIdDateTimeSettingHandler(IRepository repository, IQClaims claims) : IQueryHandler<long, GetByIdDateTimeSettingDto>
{
    public async Task<QResult<GetByIdDateTimeSettingDto?>> Handle(QueryRequest<long, GetByIdDateTimeSettingDto> request, CancellationToken cancellationToken)
    {

        var result = await repository.FirstOrDefaultAsync(Specs.Common.GetByColumn<ControllerDateTime>("ControllerId", request.Request), cancellationToken, true, false);
        if (result.Status == Status.Exception)
            throw result.Exception!;
        var mapped = DateTimeDtoExtensionMethods.AsDomainModel(result.Value!);
        return mapped;
    }
}
