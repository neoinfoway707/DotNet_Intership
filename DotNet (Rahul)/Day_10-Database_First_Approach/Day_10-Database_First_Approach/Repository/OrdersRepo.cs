using Day_10_Database_First_Approach.Data;
using Day_10_Database_First_Approach.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_10_Database_First_Approach.Repository
{
    public class OrdersRepo(AppDbContext _context) : IOrdersRepo
    {
        public async Task<bool> CreateOrder(Order order)
        {
            if (order == null)
                return false;
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int? id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditOrder(int id, Order order)
        {
            if (order == null)
                return false;
            var findCustomer = await _context.Orders.AnyAsync(x => x.Id == id);
            if (!findCustomer)
                return false;

            _context.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var appDbContext = _context.Orders.Include(o => o.Customer);
            return await appDbContext.ToListAsync();
        }

        public async Task<bool> GetByIdOrder(int id)
        {
            var check = await _context.Orders.AnyAsync(e => e.Id == id);
            return check;
        }

        public async Task<Order?> IsOrderExists(int? id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}