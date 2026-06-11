using Day_11_Database_First_Approach.Data;
using Day_11_Database_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_11_Database_First_Approach.Repositories
{
    public class MedicinesRepository(AppDbContext _context) : IMedicinesRepository
    {
        public async Task Create(Medicine medicine)
        {
            _context.Add(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int? id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
                return false;
            
            medicine.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Medicine?> GetByIdMadicine(int? id)
        {
            return await _context.Medicines.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Edit(int id, Medicine medicine)
        {
            if (medicine == null)
                return false;
            var exists = await _context.Medicines.AnyAsync(x => x.Id == id);
            if (!exists)
                return false;
            _context.Update(medicine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Medicine>> GetAllMadicines()
        {
            return await _context.Medicines.OrderBy(x => x.IsDeleted).ToListAsync();
        }

        public async Task<bool> IsMedicineExists(int id)
        {
            return await _context.Medicines.AnyAsync(e => e.Id == id);
        }

        public async Task<Medicine?> RetriveMadicine(int id)
        {
            var findMedicine = await _context.Medicines.FirstOrDefaultAsync(X => X.Id == id);
            if (findMedicine == null)
                return null;
            findMedicine.IsDeleted = false;
            await _context.SaveChangesAsync();
            return findMedicine;
        }
    }
}