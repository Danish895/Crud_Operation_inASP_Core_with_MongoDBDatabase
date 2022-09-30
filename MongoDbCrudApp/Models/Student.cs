using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace MongoDbCrudApp.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("job")]
        public string Job { get; set; }

        [BsonElement("salary")]
        public int Salary { get; set; }
    }
}
