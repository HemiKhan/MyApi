namespace Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.ReaderDTOs;
using Domain.Models.ControllerModels.DoorModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public record GetByIdDoorHandler(IRepository Repository) : IQueryHandler<long, Door_GetById_DTO>
{
    public async Task<QResult<Door_GetById_DTO?>> Handle(QueryRequest<long, Door_GetById_DTO> request, CancellationToken cancellationToken)
    {
        var getByIdSpec = new GenericQSpec<Door, Door_GetById_DTO>()
        {
            SpecificationFunc = _ =>
            _.Where(_ => _.Id == request.Request)
            .Include(_ => _.DoorAdvanceConfiguration)
            .Include(_ => _.Readers)
            .ThenInclude(_ => _.ReaderIdentificationType)
            .Include(_ => _.Rexes)
            .Select(o => new Door_GetById_DTO
            ( 
               o.Id,
               o.ControllerId,
               o.Name,
               o.Lock,
               o.DoorType,
               new DoorAdvanceConfig_GetById_DTO(
                                            o.DoorAdvanceConfiguration.Id,
                                            o.DoorAdvanceConfiguration.DuringScheduleId,
                                            o.DoorAdvanceConfiguration.UnlockScheduleId,
                                            o.DoorAdvanceConfiguration.LockMonitor,
                                            o.DoorAdvanceConfiguration.LockType,
                                            o.DoorAdvanceConfiguration.DoorMonitor,
                                            o.DoorAdvanceConfiguration.EnableSupervisedInputs,
                                            o.DoorAdvanceConfiguration.PreAlarmTime,
                                            o.DoorAdvanceConfiguration.OpenTooLongTime,
                                            o.DoorAdvanceConfiguration.CancelAccessTimeOnceDoorIsOpened,
                                            o.DoorAdvanceConfiguration.RelockTime,
                                            o.DoorAdvanceConfiguration.AccessTime,
                                            o.DoorAdvanceConfiguration.LongAccessTime,
                                            o.DoorAdvanceConfiguration.LockWhenLocked,
                                            o.DoorAdvanceConfiguration.LockWhenUnlocked,
                                            o.DoorAdvanceConfiguration.RelayStateLocked,
                                            o.DoorAdvanceConfiguration.BoltInTime,
                                            o.DoorAdvanceConfiguration.BoltOutTime,
                                            o.DoorAdvanceConfiguration.IsAntiPassback,
                                            o.DoorAdvanceConfiguration.AntipassbackMode,
                                            o.DoorAdvanceConfiguration.IsDoorMonitor,
                                            o.DoorAdvanceConfiguration.AntiPassbackTimeout,
                                            o.DoorAdvanceConfiguration.AntiPassbackEnforcementMode
                                            ),
               o.Readers.Select(x => new Reader_GetById_DTO
               (
                    x.Id,
                    x.ControllerId,
                    x.DoorId,
                    x.ReaderType,
                    x.Protocol,
                    x.LEDType,
                    x.Name,
                    x.Description,
                    x.AreaInId,
                    x.AreaOutId,
                    x.Location,
                    x.HeartbeatInterval,
                    x.Timeout,
                    x.LPNCameraSN!,
                    x.IsTimeAttendance,
                    x.IsEnrollmentReader,
                    x.LEDActiveLevel,
                    x.TamperingType,
                    x.BeeperType,
                    x.ReaderIdentificationType
                    .Select(_ => new ReaderIdentificationType_GetById_DTO(_.Id) {
                        IdentificationType = _.IdentificationType,
                        DuringScheduleId = _.DuringScheduleId,
                        ExceptScheduleId = _.ExceptScheduleId
                    }))
               ),

               o.Rexes.Select(r => new Rex_GetById_DTO
               (
                    r.Id,
                    r.RexConnection,
                    r.RexDuringScheduleId,
                    r.RexExceptScheduleId,
                    r.IsRexNotUnlockDoor,
                    r.RexType
               ))
            ))
        };
        var getAllControllerResult = await Repository.FirstOrDefaultAsync(getByIdSpec, cancellationToken);
        if (getAllControllerResult.Status is Status.Exception)
            return getAllControllerResult.Exception!;


        return getAllControllerResult;

    }
}
