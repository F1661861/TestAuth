using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestAuth.App.Interface;
using TestAuth.App.SSO;
using TestAuth.Infrastructrue.Cache;
using TestAuth.Repository;
using TestAuth.Repository.Domain;
using TestAuth.Repository.Interface;

namespace TestAuth.App
{
    /// <summary>
    /// IOC容器 Autofac扩展
    /// </summary>
    public static class AutofacExt
    {
        public static void InitAutofac(ContainerBuilder builder)
        {
            //注册基础类型
            //builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));

            builder.RegisterType(typeof(RepositoryBase<User>)).As(typeof(IRepository<User>));

            //注册APP层
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            builder.RegisterType(typeof(LocalAuth)).As(typeof(IAuth));

            builder.RegisterType(typeof(CacheContext)).As(typeof(ICacheContext));
            //builder.RegisterType(typeof(HttpContextAccessor)).As(typeof(IHttpContextAccessor));
        }
    }
}
