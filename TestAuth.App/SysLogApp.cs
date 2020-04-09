using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestAuth.Repository.Domain;
using TestAuth.Repository.Interface;

namespace TestAuth.App
{
    public class SysLogApp : BaseApp<SysLog>
    {
        public SysLogApp(IRepository<SysLog> repository)
            :base(repository)
        {

        }

        public void Add(SysLog obj)
        {
            //程序类型取入口应用的名称，可以根据自己需要调整
            obj.Application = Assembly.GetEntryAssembly().FullName.Split(',')[0];
            Repository.Add(obj);
        }
    }
}
