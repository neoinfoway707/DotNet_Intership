using Day_16_HTTP_Methods_with_WebAPI.Dtos;
using Day_16_HTTP_Methods_with_WebAPI.Models;

namespace Day_16_HTTP_Methods_with_WebAPI.Services
{
    public class ApiMonitorServices : IApiMonitorServices
    {
        private static readonly List<ApiMonitor> _monitors = new List<ApiMonitor>()
        {
            new ApiMonitor { Id = 1, EndpointUrl = "https://api.niotechone.com/v1/jobs", Method = "GET", ExpectedStatusCode = 200, IsEnvironmentProduction = true },
            new ApiMonitor { Id = 2, EndpointUrl = "https://api.techflow.io/v2/automation/start", Method = "POST", ExpectedStatusCode = 201, IsEnvironmentProduction = true },
            new ApiMonitor { Id = 3, EndpointUrl = "https://sandbox.innovatecqrs.lab/auth/login", Method = "POST", ExpectedStatusCode = 200, IsEnvironmentProduction = false },
            new ApiMonitor { Id = 4, EndpointUrl = "https://appliance-shark.com/sitemap.xml", Method = "GET", ExpectedStatusCode = 404, IsEnvironmentProduction = true }
        };

        public List<ApiMonitor> GetAllApiMonitors()
        {
            return _monitors;
        }
        public ApiMonitor? GetApiMonitorById(int id)
        {
            var find = _monitors.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return null;
            return find;
        }
        public ApiMonitor CreateApiMonitor(ApiMonitorDto apiMonitorDto)
        {
            var apiMonitor = new ApiMonitor
            {
                EndpointUrl = apiMonitorDto.EndpointUrl,
                Method = apiMonitorDto.Method,
                ExpectedStatusCode = apiMonitorDto.ExpectedStatusCode,
                IsEnvironmentProduction = apiMonitorDto.IsEnvironmentProduction
            };
            apiMonitor.Id = _monitors.Max(c => c.Id) + 1;
            _monitors.Add(apiMonitor);
            return apiMonitor;
        }

        public ApiMonitor? UpdateApiMonitor(int id, ApiMonitorDto apiMonitorDto)
        {
            var apiMonitor = new ApiMonitor
            {
                EndpointUrl = apiMonitorDto.EndpointUrl,
                Method = apiMonitorDto.Method,
                ExpectedStatusCode = apiMonitorDto.ExpectedStatusCode,
                IsEnvironmentProduction = apiMonitorDto.IsEnvironmentProduction
            };

            var find = _monitors.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return null;

            find.EndpointUrl = apiMonitorDto.EndpointUrl;
            find.Method = apiMonitorDto.Method;
            find.ExpectedStatusCode = apiMonitorDto.ExpectedStatusCode;
            find.IsEnvironmentProduction = apiMonitorDto.IsEnvironmentProduction;

            return find;
        }
        public bool DeleteApiMonitor(int id)
        {
            var find = _monitors.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return false;
            _monitors.Remove(find);
            return true;
        }
    }
}