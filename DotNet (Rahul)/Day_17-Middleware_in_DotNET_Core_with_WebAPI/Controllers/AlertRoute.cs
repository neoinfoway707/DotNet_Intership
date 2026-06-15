namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Controllers
{
    public class AlertRoute
    {
        public const string basic = "api";

        public class Alert
        {
            public const string GetAllAlert = basic + "/Alert";
            public const string GetAlertById= basic + "/Alert/{id:int:min(1)}";
            public const string CreateAlert= basic + "/Alert";
            public const string UpdateAlert = basic + "/Alert/{id:int:min(1)}";
            public const string DeleteAlert= basic + "/Alert/{id:int:min(1)}";
        }
    }
}
