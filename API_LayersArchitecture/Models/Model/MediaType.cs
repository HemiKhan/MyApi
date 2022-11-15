using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class MediaType
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string? PrincileType { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime Date { get; set; }
    }
}
