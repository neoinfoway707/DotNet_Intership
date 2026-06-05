using Day_7_Web_API_in_MVC.Application.Dto;
using Day_7_Web_API_in_MVC.Domain.Entities;

namespace Day_7_Web_API_in_MVC.Application.Interface
{
    public interface IServerRepo
    {
        Task<List<Server>> GetAll();
        Task<Server?> GetById(int id);
        Task<Server?> AddServer(ServerDto dto);
        Task<Server?> UpdateServer(int id, ServerDto dto);
        Task<Server?> DeleteServer(int id);

    }
}
