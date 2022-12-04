using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Seeding
{
    public class PrioritiesSeeder
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string? Name { get; set; }
        public int? PriortyLevel { get; set; }
        public string? ColorCode { get; set; }
    }
}
