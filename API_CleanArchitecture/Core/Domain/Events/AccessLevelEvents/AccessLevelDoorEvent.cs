namespace Domain.Events.AccessLevelEvents;

using Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessLevelDoor_Created(long AccessLevelId, long DoorId, long ScheduleId, long? ExceptScheduleId) : IDomainEvent { }
public record AccessLevelDoor_Added(Add_AccessLevelDoor_DTO dto, long AccessLevelId) : IDomainEvent { }
public record AccessLevelDoor_Updated(long AccessLevelId,Update_AccessLevelDoor_Parameters OldValue, Update_AccessLevelDoor_Parameters NewValue) : IDomainEvent { } 
