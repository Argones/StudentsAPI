using Microsoft.EntityFrameworkCore;
using StudentsAPI.Data;

namespace StudentsAPI.Services.StudentServices
{
    public class StudentService : IStudentService
    {
       
        private readonly DataContext _data;

        public StudentService(DataContext data)
        {
            _data = data;
        }

        public async Task<List<Student>> AddStudent(Student student)
        {
            _data.Students.Add(student);

            await _data.SaveChangesAsync();

            return await _data.Students.ToListAsync();
        }

        public async Task<List<Student>?> DeleteStudent(int id)
        {
            var student = await _data.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _data.Students.Remove(student);

            await _data.SaveChangesAsync();

            return await _data.Students.ToListAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _data.Students.ToListAsync();
            return students;
        }

        public async Task<Student?> GetSingleStudent(int id)
        {
            var student = await _data.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }

            return student;
        }

        public async Task<List<Student>?> UpdateStudent(Student request, int id)
        {
            var student = await _data.Students.FindAsync(id);
            if (student is null)
            {
                return null;
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Age = request.Age;
            student.Email = request.Email;
            student.Class = request.Class;

            await _data.SaveChangesAsync();

            return await _data.Students.ToListAsync();
        }
    }
}
