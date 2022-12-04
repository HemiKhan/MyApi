namespace Domain.Models;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Events;
using Domain.Models.CardFormatsModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record Area
{
    public static Area Create(AddAreaDto cmd) => new Area(
        cmd.Name,
        cmd.IsEntrance
                      );
    public void Update(UpdateAreaDto dto)
    {
        if (!Name.Equals(dto.Name))
        {
            var e = new AreaName_Updated(Id, Name, dto.Name);
            RegisterEvent(e);
        }
        if (!IsEntrance.Equals(dto.IsEntrance))
        {
            var e = new AreaEntrance_Updated(Id, IsEntrance, dto.IsEntrance);
            RegisterEvent(e);
        }
    }

    public Deleted<Area> Delete()
    {
        var e = new Area_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Area>(this, e);
    }
}
