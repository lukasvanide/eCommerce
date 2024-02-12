using Shop.Domain;
using Shop.Domain.Cashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Cashing
{
    public  class InMemoryChaching<T> : IInMemoryCaching<T> 
    {
        private  readonly Dictionary<string, T> _cache = new Dictionary<string, T>();
        private  readonly Dictionary<string, DateTime> _expirationTimes = new Dictionary<string, DateTime>();

        public async Task Set(string key, T value, TimeSpan expiration)
        {
            _cache.Add(key, value);
            _expirationTimes[key] = DateTime.UtcNow.Add(expiration);

        }

        public  async Task<T> Get(string key)
        {

            if (_expirationTimes.TryGetValue(key, out DateTime expirationTime) && expirationTime >= DateTime.UtcNow)
            {
                if (_cache.TryGetValue(key, out T cachedValue))
                {
                    return cachedValue;
                }
            }
            else
            {
                _cache.Remove(key);
                _expirationTimes.Remove(key);
            }

            return default;
        }
    }
}
