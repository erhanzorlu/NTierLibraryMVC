﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.VMClasses
{
    public class BookVM
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public int Page { get; set; }
        public string PhotoPath { get; set; }
        public decimal? Price { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
    }
}
