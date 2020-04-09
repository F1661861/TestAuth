using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuth.Infrastructrue.Cache
{
    public class CacheContext : ICacheContext
    {
        private IMemoryCache _objCache;

        public CacheContext(IMemoryCache memoryCache)
        {
            _objCache = memoryCache;
        }
        public override T Get<T>(string key)
        {
           return _objCache.Get<T>(key);
        }

        public override bool Remove(string key)
        {
            _objCache.Remove(key);
            return true;
        }

        public override bool Set<T>(string key, T t, DateTime expire)
        {
            var obj = Get<T>(key);
            if (obj!=null)
            {
                Remove(key);
            }
            _objCache.Set<T>(key, t, new MemoryCacheEntryOptions().SetAbsoluteExpiration(expire)); //绝对过期时间

            return true;
        }
    }
}
