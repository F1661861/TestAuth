using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.App.SSO;

namespace TestAuth.App.Interface
{
    public interface IAuth
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="appkey">登录的应用appkey</param>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        LoginResult Login(string appkey, string name, string password);
    }
}
