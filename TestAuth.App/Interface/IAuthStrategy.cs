using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.Repository.Domain;

namespace TestAuth.App.Interface
{
    public interface IAuthStrategy
    {
        User User
        {
            get; set;
        }
    }
}
