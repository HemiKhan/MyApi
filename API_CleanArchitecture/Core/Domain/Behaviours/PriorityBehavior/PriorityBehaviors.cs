namespace Domain.Models.PrioritiesModels;

using System;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Events.PriorityEvents;
using SharedKernel.Interfaces;

public partial record Priority
{
    public static Priority Create(AddPriorityDTO dto)
    {
        return new Priority
            (
             dto.Name,
             dto.ColorCode,
             dto.PriorityLevel
            );
    }

    public IDeleted<Priority> Deleted()
    {
        var e = new Priority_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Priority>(this, e);
    }
    public void Update(Update_PriorityDTO dto)
    {
        if (Name != dto.Name)
        {
            var e = new Priority_NameUpdated(Id, Name, dto.Name);
            ApplyAndRegisterEvent(e);
        }
        if (PriorityLevel != dto.PriorityLevel)
        {
            var e = new Priority_PrioeirtyLevelUpdated(Id, PriorityLevel, dto.PriorityLevel);
            ApplyAndRegisterEvent(e);
        }
        if (ColorCode != dto.ColorCode)
        {
            var e = new Priority_ColorCodeUpdated(Id, ColorCode, dto.ColorCode);
            ApplyAndRegisterEvent(e);
        }
    }

    protected override void When(IDomainEvent @event) 
    {

    }
}
