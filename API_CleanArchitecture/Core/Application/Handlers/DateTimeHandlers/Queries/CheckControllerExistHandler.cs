namespace Application.Handlers.DateTimeHandlers.Queries;

using Application.Common;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Models.ControllerModels;


internal record CheckControllerExistHandler(IRepository repo) : IQueryHandler<long, bool>
{
    public async Task<QResult<bool>> Handle(QueryRequest<long, bool> request, CancellationToken cancellationToken)
    {
        var controllerExist = await repo.FirstOrDefaultAsync(Specs.Common.GetById<Controller, long>(request.Request), cancellationToken, true, false);

        return controllerExist.Status is Status.Exception ? controllerExist.Exception! : false;
    }
}
