namespace Domain.Models.AccessConfigsModels;

using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessConfig : AggregateRoot<long>,IMustHaveOrganization
{
  

    AccessConfig()
    {

    }
    public long ParentId { get; private set; }
    public long OrganizationId { get; private set; }
    public string? ConfigKey { get; private set; } = default!;
    public string? ConfigValue { get; private set; } = default!;    

   
}
