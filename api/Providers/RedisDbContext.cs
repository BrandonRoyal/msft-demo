using System;
using System.Net;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace api.Providers
{
    public class RedisDbContext : IDbContext
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public RedisDbContext()
        {
            var task = GetHostEntry();
            var hostEntry = task.Result;
            if (hostEntry == null || hostEntry.AddressList.Length <= 0) throw new Exception("cannot resolve host entry from hostname 'redis'");
            var ip = hostEntry.AddressList[0].ToString();
            _redis = ConnectionMultiplexer.Connect(ip);
            _db = _redis.GetDatabase();
        }

        public async Task<IPHostEntry> GetHostEntry(){
            return await Dns.GetHostEntryAsync("redis");
        }

        public string Get(string key)
        {
            return _db.StringGet(key);
        }

        public void Set(string key, string value)
        {
            _db.StringSet(key, value);
        }

        public void Delete(string key)
        {
            _db.KeyDelete(key);
        }
    }
}