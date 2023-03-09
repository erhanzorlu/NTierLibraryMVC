using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Generic_Repository.IntRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Generic_Repository.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext db;
        public BaseRepository()
        {
            db = DBTool.DB;
        }
        private void Save()
        {
            db.SaveChanges();
        }
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> items)
        {
            db.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public void Destroy(T item)
        {
            db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> items)
        {
            db.Set<T>().RemoveRange(items);
            Save();
        }

        public T Find(int id)
        {
            return db.Set<T>().Find(id);

        }

        public T FirstOrdDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x=>x.Status!=ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetCountedDatas(int number)
        {
            return db.Set<T>().Take(number).ToList();
        }

        public List<T> GetFirstDatas(int number)
        {
            return db.Set<T>().Take(number).OrderBy(x => x.CreatedTime).ToList();
        }

        public List<T> GetLastDatas(int number)
        {
            return db.Set<T>().Take(number).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated).ToList();
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted).ToList();
        }

        public void Remove(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedTime = DateTime.Now;
            Save();
        }

        public void RemoveRange(List<T> items)
        {
            foreach (var item in items)
            {
                Remove(item);
                
            }
          
        }



        public void Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.UpdatedTime = DateTime.Now;
            T toBeUpdated = Find(item.ID);
            db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> items)
        {
            foreach (var item in items)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp) where X : class
        {
            return db.Set<T>().Select(exp);
        }
    }
}
