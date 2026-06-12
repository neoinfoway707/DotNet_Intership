namespace Day_15_Validation_and_Routing_with_WebAPI.Controllers
{
    public class ApiMonitorRoute
    {
        public const string basic = "api";

        public class ApiMonitor
        {
            public const string GetAllApiMonitors = basic + "/ApiMonitor";
            public const string GetApiMonitorById = basic + "/ApiMonitor/{id:int:min(1)}";
            public const string CreateApiMonitor = basic + "/ApiMonitor";
            public const string UpdateApiMonitor = basic + "/ApiMonitor/{id:int:min(1)}";
            public const string DeleteApiMonitor = basic + "/ApiMonitor/{id:int:min(1)}";
        }
    }
}
