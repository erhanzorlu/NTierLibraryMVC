using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.VMClasses
{
    public class AdminBookVM
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string BookName { get; set; }
        public int Page { get; set; }
        public string PhotoPath { get; set; }
        public decimal? Price { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public int AuthorID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string Status { get; set; }

    }
}
