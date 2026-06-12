namespace Day_15_Validation_and_Routing_with_WebAPI.Controllers
{
    public class JobRoute
    {
        public const string basic = "api";
        public class Jobs
        {
            public const string GetAllJobs = basic + "/Jobs";
            public const string GetJobById = basic + "/Jobs/{id:int:min(1)}";
            public const string CreateJob = basic + "/Jobs";
            public const string UpdateJob = basic + "/Jobs/{id:int:min(1)}";
            public const string DeleteJob = basic + "/Jobs/{id:int:min(1)}";
        }
    }
}
