using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Project.BLL.Generic_Repository.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();

        //Modification Commands

        void Add(T item);
        void AddRange(List<T> items);

        void Remove(T item);
        void RemoveRange(List<T> items);

        void Update(T item);
        void UpdateRange(List<T> items);

        void Destroy(T item);
        void DestroyRange(List<T> items);

        // Linq Expressions

        List<T> Where(Expression<Func<T, bool>> exp); // 
        bool Any(Expression<Func<T, bool>> exp);// Kullanıcı girişinde kullanılır
        T FirstOrdDefault(Expression<Func<T,bool>>exp); // Spesifik bir objeyi bulmak için
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp) where X : class; // ???

        // Find

        T Find(int id); // Update işleminde kullanılıyor

        List<T> GetLastDatas(int number);
        List<T> GetFirstDatas(int number);
        List<T> GetCountedDatas(int number);

    }
}
