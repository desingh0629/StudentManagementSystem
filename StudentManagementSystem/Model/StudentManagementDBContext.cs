using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Model
{
    public class StudentManagementDBContext : IdentityDbContext
    {
        public StudentManagementDBContext(DbContextOptions<StudentManagementDBContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
