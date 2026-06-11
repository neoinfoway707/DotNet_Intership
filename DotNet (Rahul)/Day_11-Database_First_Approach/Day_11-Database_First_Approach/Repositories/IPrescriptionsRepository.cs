using Day_11_Database_First_Approach.Models;

namespace Day_11_Database_First_Approach.Repositories
{
    public interface IPrescriptionsRepository
    {
        Task<List<Prescription>> GetAllPrescription();
        Task<bool> IsPrescriptionExists(int id);
        Task CreatePrescription(Prescription prescription);
        Task<Prescription?> GetByIdPrescription(int id);
        Task<bool> EditPrescription(int id, Prescription prescription);
        Task<bool> DeletePrescription(int? id);
        Task<bool> RetrievePrescription(int id);
    }
}
