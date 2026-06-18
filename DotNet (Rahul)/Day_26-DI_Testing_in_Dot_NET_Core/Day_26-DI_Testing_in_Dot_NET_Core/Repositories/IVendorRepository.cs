using Day_26_DI_Testing_in_Dot_NET_Core.Dtos;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Repositories
{
    public interface IVendorRepository
    {
        Task<List<VendorResponseDto>> GetallVendorsAsync();
        Task<VendorResponseDto?> GetVendroByIdAsync(int id);
        Task<VendorResponseDto> CreateVendorAsync(VendorRequestDto dto);
        Task<VendorResponseDto?> UpdateVendorAsync(int id, VendorRequestDto dto);
        Task<bool> DeleteVendorAsync(int id);
    }
}
