using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models
{
    public class Task
    {
        public ObjectId Id { get; set; }

        [BsonElement("TaskId")]
        public int TaskId { get; set; }

        [BsonElement("Task")]
        public string TaskDetail { get; set; }
    }
}