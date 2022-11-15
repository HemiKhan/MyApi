using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }
        public string EmailType { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? CC { get; set; }
        public string? BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Link { get; set; }
        [NotMapped]
        public List<EmailPlaceholder> Placeholders { get; set; }
    }
}
