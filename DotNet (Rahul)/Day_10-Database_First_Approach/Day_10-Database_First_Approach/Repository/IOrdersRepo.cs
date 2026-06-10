using Day_10_Database_First_Approach.Models;

namespace Day_10_Database_First_Approach.Repository
{
    public interface IOrdersRepo
    {
        Task<List<Order>> GetAllOrders();
        Task<bool> GetByIdOrder(int id);
        Task<bool> CreateOrder(Order order);
        Task<Order?> IsOrderExists(int? id);
        Task<bool> EditOrder(int id, Order order);
        Task<bool> DeleteOrder(int? id);
    }
}
