using Day_28_Advanced_Repository_Techniques.Dtos;

namespace Day_28_Advanced_Repository_Techniques.Repositories
{
    public interface IMedicleSupplyRepository
    {
        Task<(List<MedicleSupplyResponseDto> Items, int TotalCount)> GetallMedicleSupplysAsync(MedicleSupplyQueryParams queryParams);
        Task<MedicleSupplyResponseDto?> GetMedicleSupplyIdAsync(int id);
        Task<MedicleSupplyResponseDto?> CreateMedicleSupplyAsync(MedicleSupplyRequestDto dto);
        Task<MedicleSupplyResponseDto?> UpdateMedicleSupplyAsync(int id, MedicleSupplyRequestDto medicleSupply);
        Task<bool> DeleteMedicleSupplyAsync(int id);
    }
}
