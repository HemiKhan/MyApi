using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class Tool
    {
        [Key]
        public Guid ToolId { get; set; }
        public string? Name { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
