using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AuthorDetail:BaseEntity
    {
        public byte Age { get; set; }
        public string Country { get; set; }

        //Relational Properties

        public Author Author { get; set; }

    }
}
