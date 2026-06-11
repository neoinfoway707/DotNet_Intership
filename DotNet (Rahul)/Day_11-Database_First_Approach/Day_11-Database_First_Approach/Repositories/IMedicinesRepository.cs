using Day_11_Database_First_Approach.Models;

namespace Day_11_Database_First_Approach.Repositories
{
    public interface IMedicinesRepository
    {
        Task<List<Medicine>> GetAllMadicines();
        Task<bool> IsMedicineExists(int id);
        Task Create(Medicine medicine);
        Task<Medicine?> GetByIdMadicine(int? id);
        Task<bool> Edit(int id, Medicine medicine);
        Task<bool> Delete(int? id);
        Task<Medicine?> RetriveMadicine(int id);
    }
}