using StudentManagementSystem.Model;
using StudentManagementSystem.Model.Responce;

namespace StudentManagementSystem.Interface
{
    public interface IStudentService
    {
       Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<ServiceResponce> CreateStudent(Student student);
        Task<ServiceResponce> UpdateStudent(int id, Student student);
        Task<ServiceResponce> DeleteStudent(int id);
    }
}
