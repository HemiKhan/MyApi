namespace Application.Handlers.Queries.OutputSensorHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Constants;
using Domain.Models.OutputSensorModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetAllOutputSenserHanlder(IRepository Repository) : IQueryHandler<long, IEnumerable<IOModel>>
{
    public async Task<QResult<IEnumerable<IOModel>?>> Handle(QueryRequest<long, IEnumerable<IOModel>> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<ControllerIOPorts, IOModel>()
        {
            SpecificationFunc = _ => _.Where(_ => _.ControllerId == request.Request)
            .Select(
                _ => new IOModel { Id = _.Id, ControllerId = _.ControllerId, Name = _.Name, PortType = _.PortType, State = _.State, IONumber = _.IONumber, Status = _.Status }
                )
        };
        var Result = await Repository.GetAllAsync(specs,
            cancellationToken,
           false, false
            );
        if (Result.Value.Count() == 0)
        {

            var list = new List<IOModel>();
            var rec1 = new IOModel { IO = "AUX 1", Name = "AUX IO1", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 0 }; list.Add(rec1);
            var rec2 = new IOModel { IO = "AUX 2", Name = "AUX IO2", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 1 }; list.Add(rec2);
            var rec3 = new IOModel { IO = "AUX 3", Name = "AUX IO3", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 2 }; list.Add(rec3);
            var rec4 = new IOModel { IO = "AUX 4", Name = "AUX IO4", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 3 }; list.Add(rec4);
            var rec5 = new IOModel { IO = "GLASS IO13", Name = "GLASS IO13", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 12 }; list.Add(rec5);
            var rec6 = new IOModel { IO = "EMERGENCY IO14", Name = "EMERGENCY IO14", State = Domain.Constants.State.Opencircut, PortType = PortType.Input, Status = "Open Circut", IONumber = 13 }; list.Add(rec6);

            return list;
        }
        else
        {
            var converted = Result.Value!.ToArray();
            converted[0].IO = "AUX 1";
            converted[1].IO = "AUX 2";
            converted[2].IO = "AUX 3";
            converted[3].IO = "AUX 4";
            converted[4].IO = "GLASS IO13";
            converted[5].IO = "EMERGENCY IO14";
            return converted;
        }
    }
}
