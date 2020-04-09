using System;
using System.Collections.Generic;
using System.Text;
using TestAuth.App.Interface;
using TestAuth.Repository.Domain;

namespace TestAuth.App.AuthStrategies
{
    public class AuthStrategyContext
    {
        private readonly IAuthStrategy _strategy;
        public AuthStrategyContext(IAuthStrategy strategy)
        {
            this._strategy = strategy;
        }

        public User User
        {
            get { return _strategy.User; }
        }
    }
}
