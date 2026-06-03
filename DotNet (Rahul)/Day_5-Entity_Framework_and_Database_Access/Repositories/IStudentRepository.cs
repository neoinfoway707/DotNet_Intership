using Day_5_Entity_Framework_Database_Access.Models;

namespace Day_5_Entity_Framework_and_Database_Access.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();

        Task AddStudent(Student student);

        Task<Student?> GetById(int id);

        Task<bool> UpdateStudent(int id, Student student);

        Task<bool> DeleteStudent(int id);

    }
}
