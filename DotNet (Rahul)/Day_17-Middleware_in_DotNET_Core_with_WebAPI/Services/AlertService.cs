using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Dtos;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Models;

namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Services
{
    public class AlertService : IAlertService
    {
        private static readonly List<Alert> _alerts = new List<Alert>()
        {
            new Alert { Id = 1, Title = "High CPU Usage", Message = "CPU utilization exceeded 95% on production server.", Severity = "Critical", Source = "Niotechone Solutions Server", CreatedAt = DateTime.Parse("2026-06-12 09:30:00 AM"), IsResolved = false },
            new Alert { Id = 2, Title = "Automation Delay", Message = "n8n background workflow execution took longer than 30 seconds.", Severity = "Warning", Source = "TechFlow Automation Node", CreatedAt = DateTime.Parse("2026-06-12 02:15:45 PM"), IsResolved = true },
            new Alert { Id = 3, Title = "Database Connection Failed", Message = "Failed to connect to SQL database instance during login.", Severity = "Error", Source = "InnovateCQRS Lab Sandbox", CreatedAt = DateTime.Parse("2026-06-11 11:00:12 AM"), IsResolved = false },
            new Alert { Id = 4, Title = "SSL Certificate Expiry", Message = "SSL certificate for the main domain expires in 3 days.", Severity = "Info", Source = "Appliance Shark Web Gateway", CreatedAt = DateTime.Parse("2026-06-10 04:45:20 PM"), IsResolved = true }
        };
        public List<Alert> GetallAlerts()
        {
            return _alerts;
        }
        public Alert? GetAlertById(int id)
        {
            var check = _alerts.FirstOrDefault(x => x.Id == id);
            if (check == null)
                return null;
            return check;
        }
        public Alert CreateAlert(AlertDto alertDto)
        {
            var alert = new Alert
            {
                Title = alertDto.Title,
                Message = alertDto.Message,
                Severity = alertDto.Severity,
                Source = alertDto.Source,
                CreatedAt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsResolved = alertDto.IsResolved
            };
            alert.Id = _alerts.Max(x => x.Id) + 1;
            _alerts.Add(alert);
            return alert;
        }

        public Alert? UpdateAlert(int id, AlertDto alertDto)
        {
            var alert = new Alert
            {
                Title = alertDto.Title,
                Message = alertDto.Message,
                Severity = alertDto.Severity,
                Source = alertDto.Source,
                IsResolved = alertDto.IsResolved
            };
            var find = _alerts.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return null;
            find.Title = alertDto.Title;
            find.Message = alertDto.Message;
            find.Severity = alertDto.Severity;
            find.Source = alertDto.Source;
            find.IsResolved = alertDto.IsResolved;

            return find;
        }
        public bool DeleteAlert(int id)
        {
            var check = _alerts.FirstOrDefault(x => x.Id == id);
            if (check == null)
                return false;
            _alerts.Remove(check);
            return true;
        }
    }
}
