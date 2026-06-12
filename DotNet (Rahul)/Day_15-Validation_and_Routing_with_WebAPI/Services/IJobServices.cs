using Day_15_Validation_and_Routing_with_WebAPI.Dtos;
using Day_15_Validation_and_Routing_with_WebAPI.Models;

namespace Day_15_Validation_and_Routing_with_WebAPI.Services
{
    public interface IJobServices
    {
        List<Job> GetAllJobs();
        Job? GetJobById(int id);
        Job CreateJob(JobsDto jobDto);
        Job? UpdateJob(int id, JobsDto jobsDto);
        bool DeleteJob(int id);
    }
}
