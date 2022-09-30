using Microsoft.AspNetCore.Mvc;
using MongoDbCrudApp.DataAccessLayer.Repository;
using MongoDbCrudApp.Models;

namespace MongoDbCrudApp.Service
{
    public class StudentService : IStudentService
    {
        public IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            return await _studentRepository.CreateAsync(student);
        }

        public Task<List<Student>> GetAsync()
        {
            return _studentRepository.GetAsync();

        }

        public async Task RemoveAsync(string id)
        {
            await _studentRepository.RemoveAsync(id);

        }

        public async Task UpdateAsync(string id, Student student)
        {
            await _studentRepository.UpdateAsync(id, student);
        }
    
    }
}
