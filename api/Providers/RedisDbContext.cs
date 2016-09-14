using StackExchange.Redis;

namespace api.Providers
{
    public class RedisDbContext : IDbContext
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public RedisDbContext()
        {
            _redis = ConnectionMultiplexer.Connect("127.0.0.1");
            _db = _redis.GetDatabase();
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