using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
         DBTool()
        {

        }

        static MyContext db;
        public static MyContext DB
        {
            get
            {
                if (db==null)
                {
                    db = new MyContext();
                }
                return db;
            }
        }
    }
}
