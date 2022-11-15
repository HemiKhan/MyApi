using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class Projects
    {
        [Key]
        public Guid ProjectId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Url { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Type { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
