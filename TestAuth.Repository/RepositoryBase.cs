using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TestAuth.Repository.Core;
using TestAuth.Repository.Interface;

namespace TestAuth.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private AuthDBContext _context;
        public RepositoryBase(AuthDBContext context)
        {
            _context = context;
        }
        public int ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找单个，且不被上下文所跟踪
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T FindSingle(Expression<Func<T,bool>> expression=null)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(expression);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(int pageindex = 1, int pagesize = 10, string orderby = "", Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }
            _context.Set<T>().Add(entity);
            Save();
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
