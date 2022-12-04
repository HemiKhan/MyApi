namespace Domain.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessConfigSeeder
{
    public long Id { get; set; }
    public long? ParentId { get;  set; }
    public long OrganizationId { get;  set; }
    public string? ConfigKey { get;  set; } = default!;
    public string? ConfigValue { get;  set; } = default!;
}
