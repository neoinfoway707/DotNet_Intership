using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Dtos;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Models;

namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Services
{
    public interface IAlertService
    {
        List<Alert> GetallAlerts();
        Alert? GetAlertById(int id);
        Alert CreateAlert(AlertDto alertDto);
        Alert? UpdateAlert(int id, AlertDto alertDto);
        bool DeleteAlert(int id);
    }
}
