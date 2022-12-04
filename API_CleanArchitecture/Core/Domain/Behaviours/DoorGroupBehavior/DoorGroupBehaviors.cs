namespace Domain.Models.DoorGroupModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.DoorGroupDtos;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Events.DoorGroupEvent;
using Domain.Events.ScheduleEvents;
using Domain.Models;
using Domain.Models.AccessLevelModels;
using Domain.Models.CardFormatsModels;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ControllerModels.DoorModels.RexModels;
using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public partial record DoorGroup
{
    public static DoorGroup Create(AddDoorGroupDto cmd) => new DoorGroup(
          cmd.Name
                        );
    public Deleted<DoorGroup> Delete()
    {
        var e = new DoorGroup_Deleted(this);
        RegisterEvent(e);
        return new Deleted<DoorGroup>(this, e);
    }
    public void Update(UpdateDoorGroupDto c)
    {
        var Old = new DoorGroup_UpdateEventParameters();
        var New = new DoorGroup_UpdateEventParameters();
        if (!Name.Equals(c.Name))
        {
            Old.Name = Name;
            New.Name = c.Name;
        }
        UpdateDGD(c.DGD, c.Id);
        var e = new DoorGroup_Updated(c.Id, Old, New);
        RegisterEvent(e);
    }

    private bool UpdateDGD(IEnumerable<DGDDto> dto, long id)
    {
        bool hasChanged = false;
        if (!dto.Any())
        {
            return hasChanged;
        }

        foreach (var item in DoorGroupDoors)
        {
            if (!dto.Any(_ => _.Id == item.Id))
                DoorGroupDoors.Remove(item);
        }

        foreach (var item in dto)
        {
            var ExistingItem = DoorGroupDoors.FirstOrDefault(_ => _.Id == item.Id);
            if ((!item.Id.Equals(null)) && ExistingItem == null)
                throw new QException($" Id '{item.Id}' Does Not Exists in DoorGroup");

            if (ExistingItem != null)
            {
                ExistingItem.Update(item, id);
            }
            else
            {
                var @new = Domain.Models.DoorGroupModels.DoorGroupDoors.Create(id, item.DoorId);
                DoorGroupDoors.Add(@new);
            }


        }
        return hasChanged;

    }
}