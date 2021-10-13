using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntityFood,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //List<T> GetUserFilteredDetail(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
