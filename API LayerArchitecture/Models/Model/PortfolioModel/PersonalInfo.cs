using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioModel
{
    public class PersonalInfo
    {
        [Key]
        public Guid PeronalInfoId { get; set; }
        public string? Backgroundimg { get; set; }
        public string? Profileimg { get; set; }
        public string? Cv { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? FirstName { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Country { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? City { get; set; }
        public int Age { get; set; }
        public string? Detail { get; set; }
        public string? Experience { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
