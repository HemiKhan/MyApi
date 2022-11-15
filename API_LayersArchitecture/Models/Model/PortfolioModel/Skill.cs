using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Name { get; set; }
        public int Percentage { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
