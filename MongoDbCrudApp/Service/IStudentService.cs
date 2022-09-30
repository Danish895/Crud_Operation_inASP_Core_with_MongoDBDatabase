using MongoDbCrudApp.Models;

namespace MongoDbCrudApp.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetAsync();
        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(string id, Student student);
        Task RemoveAsync(string id);
    }
}
