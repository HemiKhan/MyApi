namespace Application.Handlers.Commands.OutputSensorHandler;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Models.AccessLevelModels;
using Domain.Models.OutputSensorModel;

using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

internal record AddUpdatOutputSensorHandler(IRepository Repository) : ICommandHandler<IEnumerable<Update_ControllerIoPorts_Dto>>
{
    public async Task<QResult<long?>> Handle(CommandRequest<IEnumerable<Update_ControllerIoPorts_Dto>> request, CancellationToken cancellationToken)
    {
        if (request.Dto.Any())
        {
            //var id = request.Dto.FirstOrDefault(_ => _.Id > 0)!.Id;
            bool id = request.Dto.Where(_ => _.Id <= 0).Any()!;
            if (id)
            {
                foreach (var item in request.Dto)
                {
                    var response = await Repository.AddAsync(ControllerIOPorts.Create(item), cancellationToken);

                }
            }
            else
            {
                var ControllerId = request.Dto.Where(_ => _.ControllerId != 0).Take(1).FirstOrDefault()!.ControllerId;
                var DBEntityList = await Repository.GetAllAsync
             (
             Specs.Common.GetByColumn<ControllerIOPorts>("ControllerId", ControllerId),
             cancellationToken, false, false);
                var controllerIOPorts = DBEntityList.Value!.ToArray();
                var dtolist = request.Dto.ToArray();
                for (int i = 0; i < controllerIOPorts!.Count(); i++)
                {
                    await Repository.EnableChangeTracker(controllerIOPorts[i]);
                    controllerIOPorts[i].UpdateControllerIOPorts(dtolist[i]);
                }
                var qRepositoryUpdateResult = await Repository.SaveChangesAsync(cancellationToken);
                if (qRepositoryUpdateResult.Status is Status.Exception)
                    return qRepositoryUpdateResult.Exception!;
            }
        }
        return 1;
    }
}
