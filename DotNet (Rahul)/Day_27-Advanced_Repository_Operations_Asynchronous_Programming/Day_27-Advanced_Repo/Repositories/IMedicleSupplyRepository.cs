using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Dtos;

namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Repositories
{
    public interface IMedicleSupplyRepository
    {
        Task<(List<MedicleSupplyResponseDto> Items, int TotalCount)> GetallMedicleSupplysAsync(MedicleSupplyQueryParams queryParams);
        Task<MedicleSupplyResponseDto?> GetMedicleSupplyIdAsync(int id);
        Task<MedicleSupplyResponseDto> CreateMedicleSupplyAsync(MedicleSupplyRequestDto dto);
        Task<MedicleSupplyResponseDto?> UpdateMedicleSupplyAsync(int id, MedicleSupplyRequestDto medicleSupply);
        Task<bool> DeleteMedicleSupplyAsync(int id);
    }
}
