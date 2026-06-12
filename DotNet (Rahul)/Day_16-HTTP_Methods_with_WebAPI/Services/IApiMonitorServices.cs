using Day_16_HTTP_Methods_with_WebAPI.Dtos;
using Day_16_HTTP_Methods_with_WebAPI.Models;

namespace Day_16_HTTP_Methods_with_WebAPI.Services
{
    public interface IApiMonitorServices
    {
        List<ApiMonitor> GetAllApiMonitors();
        ApiMonitor? GetApiMonitorById(int id);
        ApiMonitor CreateApiMonitor(ApiMonitorDto jobDto);
        ApiMonitor? UpdateApiMonitor(int id, ApiMonitorDto jobsDto);
        bool DeleteApiMonitor(int id);
    }
}
