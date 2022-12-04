namespace Domain.Events.AccessConfigEvents;

using Domain.Dtos.AccessConfigDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessConfigUpdated(UpdateAccessConfigParameters Old, UpdateAccessConfigParameters New) : IDomainEvent { }