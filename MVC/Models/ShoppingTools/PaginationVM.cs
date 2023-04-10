using PagedList;
using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using Project.ViewModels.VMClasses.AdminVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.ShoppingTools
{
    public class PaginationVM
    {
        public IPagedList<Book> PagedBooks { get; set; }
       public List<Category> Categories { get; set; }
        public BookVM Book { get; set; }
    }
}