using MongoDbCrudApp.Models;

namespace MongoDbCrudApp.DataAccessLayer.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAsync();

        Task<Student> CreateAsync(Student student);
        Task UpdateAsync(string id, Student student);
        Task RemoveAsync(string id);

    }
}
