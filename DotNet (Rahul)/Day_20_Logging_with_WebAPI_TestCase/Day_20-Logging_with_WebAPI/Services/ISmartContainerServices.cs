using Day_20_Logging_with_WebAPI.Dtos;
using Day_20_Logging_with_WebAPI.Models;

namespace Day_20_Logging_with_WebAPI.Services
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
