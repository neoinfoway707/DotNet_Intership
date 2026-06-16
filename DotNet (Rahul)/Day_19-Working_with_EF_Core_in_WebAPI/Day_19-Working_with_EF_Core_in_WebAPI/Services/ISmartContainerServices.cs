using Day_19_Working_with_EF_Core_in_WebAPI.Dtos;
using Day_19_Working_with_EF_Core_in_WebAPI.Models;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Services
{
    public interface ISmartContainerServices
    {
        Task<List<SmartContainer>> GetAllSmartContainers();
        Task<SmartContainer?> GetSmartContainerById(int id);
        Task<SmartContainer> CreateSmartContainer(SmartContainerDto containerDto);
        Task<SmartContainer?> UpdateSmartContainer(int id, SmartContainerDto containerDto);
        Task<bool> DeleteSmartContainerById(int id);
    }
}
