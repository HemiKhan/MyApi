namespace Domain.Events;

using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Area_Added(string name, bool isEntrance) : IDomainEvent;
public record Area_Updated(long Id, string name, bool isEntrance) : IDomainEvent;
internal record AreaName_Updated(long Id, string Old, string New) : IDomainEvent;
internal record AreaEntrance_Updated(long Id, bool Old, bool New) : IDomainEvent;
internal record Area_Deleted(Area area) : IDeleteDomainEvent;
