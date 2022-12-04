namespace Application.Handlers.ControllerDateTimeSettingHandlers.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Models.TimeZoneModels;

public record GetAllControllersListHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<List<ControllerDateTime>>
{
    public async Task<QResult<List<ControllerDateTime>?>> Handle(QueryRequest<List<ControllerDateTime>> request, CancellationToken cancellationToken)
    {
        var spec = new GenericQSpec<ControllerDateTime>()
        {
            SpecificationFunc = _ => _.WhereOrgId(QClaims.OrganizationId)
        };
        var getAllControllerResult = await Repository.GetAllAsync(spec, cancellationToken);
        if (getAllControllerResult.Status is Status.Exception)
            return QResults.From<List<ControllerDateTime>>(getAllControllerResult);

        return QResults.From(getAllControllerResult.Value!.ToList());
    }


}
