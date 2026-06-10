using Day_10_Database_First_Approach.Data;
using Day_10_Database_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_10_Database_First_Approach.Repository
{
    public class CustomersRepo(AppDbContext _context) : ICustomersRepo
    {
        public async Task<bool> CreateCustomer(Customer customer)
        {
            if (customer == null)
                return false;
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                return false;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditCustomer(int id, Customer customer)
        {
            if (customer == null)
                return false;
            var exists = await _context.Customers.AnyAsync(x => x.Id == id);
            if (!exists)
                return false;

            _context.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<bool> GetByIdCustomer(int id)
        {
            var check = await _context.Customers.AnyAsync(e => e.Id == id);
            return check;
        }

        public async Task<Customer?> IsCustomerExists(int? id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}
