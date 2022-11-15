using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Relations.ManyToMany
{
    public class Category
    {       
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        //public virtual ICollection<Book>? Books { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
