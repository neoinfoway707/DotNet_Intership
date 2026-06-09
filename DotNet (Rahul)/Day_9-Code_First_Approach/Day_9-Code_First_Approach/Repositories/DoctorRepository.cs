using Day_9_Code_First_Approach.Data;
using Day_9_Code_First_Approach.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Numerics;

namespace Day_9_Code_First_Approach.Repositories
{
    public class DoctorRepository(AppDbContext _context) : IDoctorRepository
    {
        public async Task Create(Doctor doctor)
        {
            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetallDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }
    }
}
