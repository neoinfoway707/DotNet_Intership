using Day_10_Database_First_Approach.Models;

namespace Day_10_Database_First_Approach.Repository
{
    public interface ICustomersRepo
    {
        Task<List<Customer>> GetAllCustomers();
        Task<bool> GetByIdCustomer(int id);
        Task<bool> CreateCustomer(Customer customer);
        Task<Customer?> IsCustomerExists(int? id);
        Task<bool> EditCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int? id);
    }
}
