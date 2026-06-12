using Day_14_Dependency_Injection__in_NET_Core.Dtos;
using Day_14_Dependency_Injection__in_NET_Core.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Day_14_Dependency_Injection__in_NET_Core.Services
{
    public class LeadSubmissionService : ILeadSubmissionService
    {
        private static readonly List<LeadSubmission> _leadSubmissions = new List<LeadSubmission> 
        {
           new LeadSubmission{ LeadId = 1, FullName = "John Doe", Email = "john.doe@example.com",
                Requirements = "Web app dashboard.", Budget = 4500.00m },
            new LeadSubmission{ LeadId = 2, FullName = "Sarah Jenkins", Email = "sarah.j@techstart.io",
                Requirements = "Lead automation flow.", Budget = 2500.00m },
            new LeadSubmission{ LeadId = 3, FullName = "Rajesh Patel", Email = "rajesh@innovatesolutions.in",
                Requirements = "DevExpress PDF API.", Budget = 8000.00m },
            new LeadSubmission{ LeadId = 4, FullName = "Elena Rostova", Email = "elena.r@ecommercescale.com",
                Requirements = "Docker migration.", Budget = 12500.00m }
        };
        public List<LeadSubmission> GetLeadSubmissions()
        {
            return _leadSubmissions;
        }
        public LeadSubmission? GetLeadSubmissionById(int id)
        {
            var find = _leadSubmissions.FirstOrDefault(x => x.LeadId == id);
            if (find == null)
                return null;
            return find;
        }

        public LeadSubmission AddLeadSubmission(LeadSubmissionDto dto)
        {
            var leadSubmission = new LeadSubmission
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Requirements = dto.Requirements,
                Budget = dto.Budget
            };
            leadSubmission.LeadId = _leadSubmissions.Max(x => x.LeadId) + 1;
            _leadSubmissions.Add(leadSubmission);
            return leadSubmission;
        }

        public LeadSubmission? UpdateLeadSubmission(int id, LeadSubmissionDto dto)
        {
            var leadSubmission = new LeadSubmission
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Requirements = dto.Requirements,
                Budget = dto.Budget
            };
            var find = _leadSubmissions.FirstOrDefault(y => y.LeadId == id);
            if (find == null)
                return null;

            find.FullName = leadSubmission.FullName;
            find.Email = leadSubmission.Email;
            find.Requirements = leadSubmission.Requirements;
            find.Budget = leadSubmission.Budget;

            return find;
        }

        public bool DeleteLeadSubmission(int id)
        {
            var find = _leadSubmissions.FirstOrDefault(x=> x.LeadId == id);
            if (find == null) return false;
            _leadSubmissions.Remove(find);
            return true;
        }
    }
}