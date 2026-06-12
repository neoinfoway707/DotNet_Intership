namespace Day_14_Dependency_Injection__in_NET_Core.Controllers
{
    public class Route
    {
        public const string basic = "api";
        public class LeadSubmission
        {
            public const string GetAllLead = basic + "/LeadSubmissions";
            public const string GetLeadById = basic + "/LeadSubmissions/{id}";
            public const string CreateLead = basic + "/LeadSubmissions";
            public const string UpdateLead = basic + "/LeadSubmissions/{id}";
            public const string DeleteLead = basic + "/LeadSubmissions/{id}";
        }
    }
}
