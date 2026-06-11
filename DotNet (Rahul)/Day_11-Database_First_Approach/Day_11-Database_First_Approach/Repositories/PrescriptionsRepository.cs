using Day_11_Database_First_Approach.Data;
using Day_11_Database_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_11_Database_First_Approach.Repositories
{
    public class PrescriptionsRepository(AppDbContext _context) : IPrescriptionsRepository
    {
        public async Task CreatePrescription(Prescription prescription)
        {
            _context.Add(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePrescription(int? id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
                return false;
            prescription.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditPrescription(int id, Prescription prescription)
        {
            var check = await _context.Prescriptions.AnyAsync(x => x.Id == id && x.Id == prescription.Id);
            if (!check)
                return false;
            _context.Update(prescription);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Prescription>> GetAllPrescription()
        {
            var appDbContext = _context.Prescriptions.Include(p => p.Medicine);
            return await appDbContext.OrderBy(x => x.Medicine.IsDeleted).ToListAsync();
        }

        public async Task<Prescription?> GetByIdPrescription(int id)
        {
            return await _context.Prescriptions.FindAsync(id);
        }

        public async Task<bool> IsPrescriptionExists(int id)
        {
            return await _context.Prescriptions.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> RetrievePrescription(int id)
        {
            var find = await _context.Prescriptions.FirstOrDefaultAsync(X => X.Id == id);
            if (find == null)
                return false;
            
            find.IsDeleted = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
