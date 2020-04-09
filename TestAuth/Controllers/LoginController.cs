using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestAuth.App;
using TestAuth.App.Interface;
using TestAuth.App.Response;
using TestAuth.Infrastructrue;

namespace TestAuth.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private string _appKey = "garen";
        private IOptions<AppSetting> _appConfiguration;
        private IAuth _authUtil;

        public LoginController(IOptions<AppSetting> appConfiguration,IAuth authUtil)
        {
            _appConfiguration = appConfiguration;
            _authUtil = authUtil;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public string Login(string userName,string password)
        {
            var resp = new Response();
            try
            {
                var result = _authUtil.Login(_appKey, userName, password);
                if (result.Code==200)
                {
                    Response.Cookies.Append(Define.TOKEN_NAME, result.Token);
                }
                else
                {
                    resp.Code = 500;
                    resp.Message = result.Message;
                }
            }
            catch (Exception ex)
            {
                resp.Code = 500;
                resp.Message = ex.Message;
            }
            return JsonHelper.Instance.Serialize(resp);
        }
    }
}