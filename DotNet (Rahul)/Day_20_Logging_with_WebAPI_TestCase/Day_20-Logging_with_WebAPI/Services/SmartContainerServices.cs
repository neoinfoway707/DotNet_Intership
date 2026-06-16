using Day_20_Logging_with_WebAPI.Data;
using Day_20_Logging_with_WebAPI.Dtos;
using Day_20_Logging_with_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_20_Logging_with_WebAPI.Services
{
    public class SmartContainerServices(AppDbContext _context, ILogger<SmartContainerServices> _logger) : ISmartContainerServices
    {

        public async Task<List<SmartContainer>> GetAllSmartContainers()
        {
            _logger.LogInformation("Querying database for all active containers");
            return await _context.SmartContainers.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<SmartContainer?> GetSmartContainerById(int id)
        {
            _logger.LogInformation("Querying database for container Id {Id}", id);

            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (find == null)
            {
                _logger.LogWarning("Container Id {Id} not found in database", id);
                return null;
            }
            return find;
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
            _logger.LogInformation("Saving new container {TelemetryCode} to database", 
                    containerDto.TelemetryCode);
           
            await _context.SmartContainers.AddAsync(smartContainer);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Container {TelemetryCode} saved with Id {Id}", 
                    smartContainer.TelemetryCode, smartContainer.Id);
            return smartContainer;
        }

        public async Task<SmartContainer?> UpdateSmartContainer(int id, SmartContainerDto containerDto)
        {
            _logger.LogInformation("Querying database to update container Id {Id}", id);

            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id);

            if (find == null)
            {
                _logger.LogWarning("Container Id {Id} not found for update in database", id);
                return null;
            }
            find.TelemetryCode = containerDto.TelemetryCode;
            find.CurrentTemperature = containerDto.CurrentTemperature;
            find.HumidityPercentage = containerDto.HumidityPercentage;
            find.DestinationPort = containerDto.DestinationPort;

            await _context.SaveChangesAsync();
            _logger.LogInformation("Container Id {Id} updated successfully", id);
            return find;
        }

        public async Task<bool> DeleteSmartContainerById(int id)
        {
            _logger.LogInformation("Querying database to soft delete container Id {Id}", id);

            var find = await _context.SmartContainers.FirstOrDefaultAsync(x => x.Id == id);
            if (find == null)
            {
                _logger.LogWarning("Container Id {Id} not found for soft delete", id);
                return false;
            }

            find.IsDeleted = true;
            await _context.SaveChangesAsync();
            _logger.LogInformation("Container Id {Id} marked as deleted in database", id);
            return true;
        }
    }
}