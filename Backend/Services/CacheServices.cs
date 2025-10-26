using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using StoreEcommerce.Interfaces;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace StoreEcommerce.Services
{
    public class CacheServices : ICacheInterface
    {
        private readonly StackExchange.Redis.IDatabase _database;
        public CacheServices(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value , TimeSpan? expiry = null)
        {
            var json = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, json);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
