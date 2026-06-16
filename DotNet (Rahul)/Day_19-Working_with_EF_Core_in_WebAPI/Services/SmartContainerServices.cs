using Day_19_Working_with_EF_Core_in_WebAPI.Data;
using Day_19_Working_with_EF_Core_in_WebAPI.Dtos;
using Day_19_Working_with_EF_Core_in_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Services
{
    public class SmartContainerServices(AppDbContext _context) : ISmartContainerServices
    {

        public async Task<List<SmartContainer>> GetAllSmartContainers()
        {
            return await _context.SmartContainers.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<SmartContainer?> GetSmartContainerById(int id)
        {
            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return find == null ? null : find;
        }
        public async Task<SmartContainer> CreateSmartContainer(SmartContainerDto containerDto)
        {
            var smartContainer = new SmartContainer
            {
                TelemetryCode = containerDto.TelemetryCode,
                CurrentTemperature = containerDto.CurrentTemperature,
                HumidityPercentage = containerDto.HumidityPercentage,
                DestinationPort = containerDto.DestinationPort,
            };
            await _context.SmartContainers.AddAsync(smartContainer);
            await _context.SaveChangesAsync();
            return smartContainer;
        }

        public async Task<SmartContainer?> UpdateSmartContainer(int id, SmartContainerDto containerDto)
        {
            var smartContainer = new SmartContainer
            {
                TelemetryCode = containerDto.TelemetryCode,
                CurrentTemperature = containerDto.CurrentTemperature,
                HumidityPercentage = containerDto.HumidityPercentage,
                DestinationPort = containerDto.DestinationPort,
            };
            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id);

            if (find == null)
                return null;
            find.TelemetryCode = smartContainer.TelemetryCode;
            find.CurrentTemperature = smartContainer.CurrentTemperature;
            find.HumidityPercentage = smartContainer.HumidityPercentage;
            find.DestinationPort = smartContainer.DestinationPort;
            await _context.SaveChangesAsync();

            return find;
        }

        public async Task<bool> DeleteSmartContainerById(int id)
        {
            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null)
                return false;

            find.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}