namespace Domain.Events.QUserEvents;

using Domain.Dtos.QUserDtos.QUserFileDTOs;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record QUserFile_Added(long QUserId, string ImageName, string ImageData) : IDomainEvent;
public record QUserFile_Updated(long? Id, Update_QUserFile_EventParameters OldValue, Update_QUserFile_EventParameters NewValue) : IDomainEvent;

public record QUserFile_Deleted(QUserFile QUserFile) : IDeleteDomainEvent { }

