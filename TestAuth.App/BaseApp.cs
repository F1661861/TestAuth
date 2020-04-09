using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.Repository.Core;
using TestAuth.Repository.Interface;

namespace TestAuth.App
{

    /// <summary>
    /// 业务层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseApp<T> where T :Entity
    {
        /// <summary>
        /// 用于普通的数据库操作
        /// </summary>
        /// <value>The repository.</value>
        protected IRepository<T> Repository;

        public BaseApp(IRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
