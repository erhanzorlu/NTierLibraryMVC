using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Book:BaseEntity
    {
        public string BookName { get; set; }
        public ushort Page { get; set; }

        public int AuthorID { get; set; }

        //Relational Properties
        public Author Author { get; set; }
        public virtual List<BookCategory> BookCategories { get; set; }

        public override string ToString()
        {
            return $"{BookName}" ;
        }
    }
}
