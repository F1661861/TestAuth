using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuth.Repository.Core
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
