using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Relations.OneToOne
{
    public class PostalAddress
    {
        public int PostalAddressId { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
