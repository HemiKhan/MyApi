namespace Domain.Events.AccessLevelEvents;

using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessLevel_Created(string name, long scheduleId, long? exceptScheduleId) : IDomainEvent { }
public record AccessLevel_Deleted(AccessLevel AccessLevel) : IDeleteDomainEvent { }
public record AccessLevel_Updated(Update_AccessLevel_Parameters Old, Update_AccessLevel_Parameters New) : IDomainEvent { }