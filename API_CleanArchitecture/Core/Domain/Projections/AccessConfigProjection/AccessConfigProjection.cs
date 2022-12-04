namespace Domain.Models.AccessConfigsModels;

using Domain.Events.AccessConfigEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessConfig
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event) 
        {
            case AccessConfigUpdated e:
                Apply(e);
                break;
        }
    }

    public void Apply(AccessConfigUpdated e)
    {
        
        //if(e.New.ConfigKey != default && e.New.ConfigKey != ConfigKey) 
        //    ConfigKey = e.New.ConfigKey;
        if(e.New.ConfigValue != default && e.New.ConfigValue != ConfigValue) 
           ConfigValue = e.New.ConfigValue;
        if (e.New.ParentId != default! && e.New.ParentId != ParentId)
          ParentId = e.New.ParentId;
    }
}
