using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.App.Interface;
using TestAuth.Repository.Domain;

namespace TestAuth.App.SSO
{
    public class LocalAuth: IAuth
    {
        private LoginParse _loginParse;
        private IOptions<AppSetting> _appConfiguration;
        private SysLogApp _logApp;
        public LocalAuth(LoginParse loginParse,IOptions<AppSetting> appConfiguration,SysLogApp sysLogApp)
        {
            _loginParse = loginParse;
            _appConfiguration = appConfiguration;
            _logApp = sysLogApp;
        }

        public LoginResult Login(string appkey, string username, string password)
        {
            if (_appConfiguration.Value.IsIdentityAuth)
            {
                return new LoginResult
                {
                    Code = 500,
                    Message = "接口启动了OAuth认证，暂时不能使用该方式登录"
                };
            }

            var result = _loginParse.Do(new PassportLoginRequest
            {
                AppKey = appkey,
                Account = username,
                Password = password
            });

            var log = new SysLog
            {
                Content = $"用户登录结果：{result.Message}",
                Result = result.Code == 200 ? 0 : 1,
                CreateId = username,
                CreateName = username,
                TypeName = "登录日志"
            };

            _logApp.Add(log);

            return result;
        }
    }
}
