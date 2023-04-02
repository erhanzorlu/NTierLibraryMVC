using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Author:BaseEntity
    {
        //Bir yazarın birden çok kitabi olur ( 1-n )
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relational Properties 

        public virtual List<Book> Books { get; set; }
        public virtual AuthorDetail AuthorDetail { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ";
        }
    }
}
