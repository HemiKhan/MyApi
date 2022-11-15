using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }
        [Column(TypeName = "nvarchar(20)")]

        public string? Name { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
}
