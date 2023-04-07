using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Areas.Admin.Data.AdminPageVMs
{
    public class AdminCreateUpdateBookVM
    {
       public AdminBookVM AdminBookVMs { get; set; }
       public List<AdminAuthorVM> AdminAuthors { get; set; }
       public List<AdminCategoryVM> AdminCategoryVMs { get; set; }
    }
}