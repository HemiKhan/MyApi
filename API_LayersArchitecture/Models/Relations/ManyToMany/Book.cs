using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Relations.ManyToMany
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        //public virtual ICollection<Category>? Categories { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
