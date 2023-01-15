namespace StudentsAPI.Services.StudentServices
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetSingleStudent(int id);
        Task<List<Student>> AddStudent(Student student);
        Task<List<Student>?> UpdateStudent(Student request, int id);
        Task<List<Student>?> DeleteStudent(int id);
    }
}
