using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestAuth.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> expression = null);
        IQueryable<T> Find(Expression<Func<T, bool>> expression = null);

        IQueryable<T> Find(int pageindex = 1, int pagesize = 10, string orderby = "",
            Expression<Func<T, bool>> expression = null);

        void Add(T entity);

        void Save();

        int ExecuteSql(string sql);
    }
}
