using Day_14_Dependency_Injection__in_NET_Core.Dtos;
using Day_14_Dependency_Injection__in_NET_Core.Models;

namespace Day_14_Dependency_Injection__in_NET_Core.Services
{
    public interface ILeadSubmissionService
    {
        List<LeadSubmission> GetLeadSubmissions();
        LeadSubmission? GetLeadSubmissionById(int id);
        LeadSubmission AddLeadSubmission(LeadSubmissionDto dto);
        LeadSubmission? UpdateLeadSubmission(int id, LeadSubmissionDto dto);
        bool DeleteLeadSubmission(int id);

    }
}
