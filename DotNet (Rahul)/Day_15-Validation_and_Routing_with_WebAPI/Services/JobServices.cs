using Day_15_Validation_and_Routing_with_WebAPI.Dtos;
using Day_15_Validation_and_Routing_with_WebAPI.Models;
using static System.Net.WebRequestMethods;

namespace Day_15_Validation_and_Routing_with_WebAPI.Services
{
    public class JobServices : IJobServices
    {

        private static readonly List<Job> _jobs = new List<Job>()
        {
            new Job { Id = 1, Title = "ASP.NET Core Developer", Company = "Niotechone Solutions", Location = "Rajkot", JobType = "Full-time", Salary = 60000.00m,
                PostDate = DateTime.Parse("2026-06-01 09:30:00 AM"), IsActive = true },

            new Job { Id = 2, Title = "Automation Engineer", Company = "TechFlow Automation", Location = "Remote", JobType = "Contract", Salary = 45000.00m,
                PostDate = DateTime.Parse("2026-06-05 02:15:45 PM"), IsActive = true },

            new Job { Id = 3, Title = "Full Stack Developer", Company = "InnovateCQRS Lab", Location = "Ahmedabad", JobType = "Full-time", Salary = 85000.00m,
                PostDate = DateTime.Parse("2026-05-20 11:00:12 AM"), IsActive = true },

            new Job { Id = 4, Title = "SEO Content Strategist", Company = "Appliance Shark", Location = "Remote", JobType = "Part-time", Salary = 30000.00m,
                PostDate = DateTime.Parse("2026-06-10 04:45:20 PM"), IsActive = false }
        };

        public List<Job> GetAllJobs()
        {
            return _jobs;
        }
        public Job? GetJobById(int id)
        {
            var find = _jobs.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return null;
            return find;
        }
        public Job CreateJob(JobsDto jobDto)
        {
            var job = new Job
            {
                Title = jobDto.Title,
                Company = jobDto.Company,
                Location = jobDto.Location,
                JobType = jobDto.JobType,
                Salary = jobDto.Salary,
                PostDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsActive = jobDto.IsActive
            };
            job.Id = _jobs.Max(c => c.Id) + 1;
            _jobs.Add(job);
            return job;
        }

        public Job? UpdateJob(int id, JobsDto jobsDto)
        {
            var job = new Job
            {
                Title = jobsDto.Title,
                Company = jobsDto.Company,
                Location = jobsDto.Location,
                JobType = jobsDto.JobType,
                Salary = jobsDto.Salary,
                PostDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                IsActive = jobsDto.IsActive
            };

            var find = _jobs.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return null;
            find.Title = job.Title;
            find.Company = job.Company;
            find.Location = job.Location;
            find.JobType = job.JobType;
            find.Salary = job.Salary;
            find.PostDate = job.PostDate;
            find.IsActive = job.IsActive;

            return find;
        }
        public bool DeleteJob(int id)
        {
            var find = _jobs.FirstOrDefault(x => x.Id == id);
            if (find == null)
                return false;
            _jobs.Remove(find);
            return true;
        }
    }
}
