using StackExchange.Redis;
using System.Collections.Generic;

namespace KrediBasvuruAspApi.Services
{
    public class RedisCacheService
    {
        private readonly IConnectionMultiplexer _redisCon;
        private readonly IDatabase _cache;
        private TimeSpan ExpireTime => TimeSpan.FromDays(15);

        public RedisCacheService(IConnectionMultiplexer redisCon)
        {
            _redisCon = redisCon;
            _cache = redisCon.GetDatabase();
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _cache.StringSetAsync(key, value, ExpireTime);
        }

        public async Task Clear(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsync()
        {
            var endpoints = _redisCon.GetEndPoints();

            return endpoints
                .SelectMany(endpoint => _redisCon.GetServer(endpoint).Keys())
                .Select(key => new KeyValuePair<string, string>(key, _cache.StringGet(key)));
        }

        public void ClearAll()
        {
            var endpoints = _redisCon.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _redisCon.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }

    }
}
