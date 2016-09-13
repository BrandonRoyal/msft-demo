using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.Builders;
using System.Collections.Generic;

using api.Models;


namespace api.Providers
{
    public class DataAccess : IDataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _database;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("TaskDB");
        }

        public IEnumerable<Task> Get()
        {
            return _db.GetCollection<Task>("Tasks").FindAll();
        }

        public Task Get(ObjectId id)
        {
            var query = Query<Task>.EQ(task => task.Id, id);
            return _db.GetCollection<Task>("Tasks").FindOne(query);
        }

        public Task Create(Task task)
        {
            _db.GetCollection<Task>("Tasks").Save(task);
            return task;
        }

        public void Update(ObjectId id, Task task)
        {
            p.Id = id;
            var query = Query<Task>.EQ(task => task.Id, id);
            var operation = Update<Task>.Replace(task);
            _db.GetCollection<Task>("Tasks").Update(query, operation);
        }

        public void Remove(ObjectId id)
        {
            var query = Query<Task>.EQ(task => task.Id, id);
            _db.GetCollection<Task>("Tasks").Remove(query);
        }
    }

    public interface IDataAccess
    {
        IEnumerable<Task> Get();
        Task Get(ObjectId id);
        Task Create(Task task);
        void Update(ObjectId id, Task task);
        void Remove(ObjectId id);
    }
}