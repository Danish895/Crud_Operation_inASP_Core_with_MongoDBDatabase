using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbCrudApp.Models;

namespace MongoDbCrudApp.DataAccessLayer.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _students; 

        public StudentRepository(IStudentDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCollectionName);
        }
        public async Task<Student> CreateAsync(Student student)
        {
             await _students.InsertOneAsync(student);
            return student;
            
        }

        public async Task<List<Student>> GetAsync()
        {
            List<Student> hujh = await _students.Find(new BsonDocument()).ToListAsync();
            Console.WriteLine(hujh);
            return hujh;
        }


        public async Task RemoveAsync(string id)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("Id", id);
            await _students.DeleteOneAsync(filter);
            return;
        }

        public async Task UpdateAsync(string id, Student student)
        {
            //FilterDefinition<Student> filter = Builders<Student>.Filter.Eq("Id", id);
            //UpdateDefinition<Student> updateName = Builders<Student>.Update.AddToSet<string>("name", student.Name);
            //UpdateDefinition<Student> updateJob = Builders<Student>.Update.AddToSet<string>("job", student.Job);
            //UpdateDefinition<Student> updateSalary = Builders<Student>.Update.AddToSet<string>("salary", student.Salary.ToString());
            //await _students.UpdateManyAsync(filter, updateJob);
            //await _students.UpdateManyAsync(filter, updateJob);
            await _students.ReplaceOneAsync(x => x.Id == id, student);
            return;
        }
    }
}
