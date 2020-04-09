using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.App.Response;

namespace TestAuth.App.SSO
{
    public class LoginResult: Response<string>
    {
        public string ReturnUrl;
        public string Token;
    }
}
