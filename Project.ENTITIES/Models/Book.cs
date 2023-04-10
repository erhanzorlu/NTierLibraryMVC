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
        public int Page { get; set; }
        public string PhotoPath { get; set; }
        public decimal? Price { get; set; }
        public int AuthorID { get; set; } 
        public int? CategoryID { get; set; }

        //Relational Properties
        public Author Author { get; set; }
        public Category Category { get; set; }
        public BookCategory BookCategory { get; set; }
        public virtual List<BookCategory> BookCategories { get; set; }

        public override string ToString()
        {
            return $"{BookName}" ;
        }
    }
}
