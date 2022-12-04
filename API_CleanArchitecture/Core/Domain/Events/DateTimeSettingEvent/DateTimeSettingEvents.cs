namespace Domain.Events.DateTimeSettingEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal record DateTimeSetting_Added(long controllerId, string timeZoneValue, bool dayLightSaving, SetMode setMode, string? dHCP, string? ipAddress, string? date, string? time) : IDomainEvent;
internal record DateTimeSetting_Updated(long controllerId, string timeZoneValue, bool dayLightSaving, SetMode setMode, string? dHCP, string? ipAddress, string? date, string? time) : IDomainEvent;