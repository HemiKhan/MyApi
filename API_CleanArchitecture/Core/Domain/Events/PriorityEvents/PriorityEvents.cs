namespace Domain.Events.PriorityEvents;

using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Priority_Added(AddPriorityDTO Value) : IDomainEvent { }
public record Priority_NameUpdated(long? Id, string? Old, string? New) : IDomainEvent { }
public record Priority_PrioeirtyLevelUpdated(long? Id, int? Old, int? New) : IDomainEvent { }
public record Priority_ColorCodeUpdated(long? Id, string? Old, string? New) : IDomainEvent { }
public record Priority_Deleted(Priority Priority) : IDeleteDomainEvent { }
