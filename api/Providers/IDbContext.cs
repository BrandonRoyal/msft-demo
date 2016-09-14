namespace api.Providers 
{
    public interface IDbContext
    {
        string Get(string key);
        void Set(string key, string value);
        void Delete(string key);
    }
}