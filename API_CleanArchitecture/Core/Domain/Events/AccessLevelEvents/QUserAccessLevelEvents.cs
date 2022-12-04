namespace Domain.Events.AccessLevelEvents;

using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record QUserAccessLevel_Added(long QUserId, long AccessLevelId) :IDomainEvent;
public record QUserAccessLevel_Updated(long QUserId, Update_QUserAccessLevels_EventParameters OldValue, Update_QUserAccessLevels_EventParameters NewValue) :IDomainEvent;

public record QUserAccessLevel_Deleted(QUserAccessLevel QUserAccessLevel) : IDeleteDomainEvent { }
