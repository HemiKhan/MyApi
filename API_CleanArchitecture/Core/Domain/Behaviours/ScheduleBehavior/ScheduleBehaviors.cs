namespace Domain.Models.ScheduleModels;
using System;
using System.Runtime.CompilerServices;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Events.ScheduleEvents;
using SharedKernel.Interfaces;

public partial record Schedule
{
    public static Schedule Create(AddScheduleDTO command) => new Schedule(
                    command.Name,
                    command.Description,
                    command.IsSubtraction
                    );
    public Deleted<Schedule> Delete()
    {
        var e = new Schedule_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Schedule>(this, e);
    }
    public void Update(UpdateScheduleDTO dto)
    {
        var oldValue = new UpdateScheduleEvents();
        var newValue = new UpdateScheduleEvents();
        if (!Name.Equals(dto.Name))
        {
            // olvalue.Name = Name;
            oldValue.Name = Name;
            ///newvalue.Name = dto.name;
            newValue.Name = dto.Name;
        }
        if (!Description.Equals(dto.Description))
        {
            oldValue.Description = Description;
            newValue.Description = dto.Description;
        }
        if (!IsSubtraction.Equals(dto.IsSubtraction))
        {
            oldValue.IsSubtraction = IsSubtraction;
            newValue.IsSubtraction = dto.IsSubtraction;
        }
        var ev = new Schedule_Updated(dto.Id, oldValue, newValue);
        RegisterEvent(ev);
    }
    public void UpdateDefinitionOnly(UpdateScheduleDefinitionDTO dto)
    {
        var oldValue = new UpdateScheduleDefinitionEvents();
        var newValue = new UpdateScheduleDefinitionEvents();

        // olvalue.Name = Name;
        oldValue.Definition = Definition;
        ///newvalue.Name = dto.name;
        newValue.Definition = dto.Definition;

        var ev = new ScheduleDefinition_Updated(dto.ScheduleId, oldValue, newValue);
        RegisterEvent(ev);
    }
}
