using Day_5_Entity_Framework_Database_Access.Data;
using Day_5_Entity_Framework_Database_Access.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_5_Entity_Framework_and_Database_Access.Repositories
{
    public class StudentRepository(StudentDbContext _context) : IStudentRepository
    {
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task AddStudent(Student student)
        {
            await using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<bool> UpdateStudent(int id, Student student)
        {
            await using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                Student? stud = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (stud == null)
                    return false;

                stud.Name = student.Name;
                stud.Email = student.Email;
                stud.Course = student.Course;
                stud.Class = student.Class;
                stud.TuationFee = student.TuationFee;
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            await using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                Student? student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                    await trans.CommitAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
