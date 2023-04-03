using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Areas.Admin.Data.AdminPageVMs
{
    public class AdminCategoryListPageVM
    {
        public List<AdminCategoryVM> Categories { get; set; }
    }
}