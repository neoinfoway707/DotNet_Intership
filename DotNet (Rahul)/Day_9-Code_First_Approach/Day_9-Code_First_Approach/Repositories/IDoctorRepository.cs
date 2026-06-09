using Day_9_Code_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_9_Code_First_Approach.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetallDoctors();
        Task Create(Doctor doctor);
    }
}
