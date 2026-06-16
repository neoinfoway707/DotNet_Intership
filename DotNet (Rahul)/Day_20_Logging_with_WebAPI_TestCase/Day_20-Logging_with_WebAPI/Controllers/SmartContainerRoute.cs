namespace Day_20_Logging_with_WebAPI.Controllers
{
    public class SmartContainerRoute
    {
        public const string basic = "api";
        public class SmsrtContainer
        {
            public const string GetAllSmsrtContainer = basic + "/SmsrtContainers";
            public const string GetSmsrtContainerById = basic + "/SmsrtContainers/{id:int:min(1)}";
            public const string CreateSmsrtContainer = basic + "/SmsrtContainers";
            public const string UpdateSmsrtContainer = basic + "/SmsrtContainers/{id:int:min(1)}";
            public const string DeleteSmsrtContainer = basic + "/SmsrtContainers/{id:int:min(1)}";
        }
    }
}
