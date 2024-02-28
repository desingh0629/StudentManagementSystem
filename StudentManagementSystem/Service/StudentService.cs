using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Interface;
using StudentManagementSystem.Model;
using StudentManagementSystem.Model.Responce;

namespace StudentManagementSystem.Service
{
    public class StudentService : IStudentService
    {
        private readonly StudentManagementDBContext _context;
        public StudentService(StudentManagementDBContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id) => await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        public async Task<ServiceResponce> CreateStudent(Student student)
        {
            student.RegistrationDate = DateTime.Now;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return new ServiceResponce(true, "Student Created Successfully.");
        }

        public async Task<ServiceResponce> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
                existingStudent.Address = student.Address;
                existingStudent.Email = student.Email;
                existingStudent.PhoneNumber = student.PhoneNumber;
                await _context.SaveChangesAsync();
                return new ServiceResponce(true, "Student Updated Successfully.");

            }
            return new ServiceResponce(false, "Error occured.");
        }

        public async Task<ServiceResponce> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student != null)
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();
                return new ServiceResponce(true, "Student Deleted Successfully.");

            }
            return new ServiceResponce(false, "Error occured.");
        }
    }
}
