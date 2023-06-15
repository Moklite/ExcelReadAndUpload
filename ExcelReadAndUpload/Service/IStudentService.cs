using ExcelReadAndUpload.Models;

namespace ExcelReadAndUpload.Service
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        List<Student> SaveStudents(List<Student> students);
    }
}
