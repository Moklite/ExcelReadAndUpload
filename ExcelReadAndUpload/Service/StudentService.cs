using EFCore.BulkExtensions;
using ExcelReadAndUpload.Context;
using ExcelReadAndUpload.Models;

namespace ExcelReadAndUpload.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public List<Student> SaveStudents(List<Student> students)
        {
            _context.BulkInsert(students);
            return students;
        }
    }
}
