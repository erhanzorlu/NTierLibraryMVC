using Project.ENTITIES.Models;
using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Areas.Admin.Data.AdminPageVMs
{
    public class AdminBookListPageVM
    {
        public List<AdminAuthorVM> Authors { get; set; }
        public List<AdminBookVM> Books { get; set; }
        public List<AdminCategoryVM> Categories { get; set; }
        public List<AdminBookCategoryVM> BookCategories { get; set; }


    }
}
