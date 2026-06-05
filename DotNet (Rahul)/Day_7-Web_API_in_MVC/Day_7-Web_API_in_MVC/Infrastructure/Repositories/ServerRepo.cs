using Day_7_Web_API_in_MVC.Application.Dto;
using Day_7_Web_API_in_MVC.Application.Interface;
using Day_7_Web_API_in_MVC.Domain.Entities;
using Day_7_Web_API_in_MVC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Day_7_Web_API_in_MVC.Infrastructure.Repository
{
    public class ServerRepo : IServerRepo
    {
        public readonly ServerDbContext _context;
        public ServerRepo(ServerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Server>> GetAll()
        {
            return await _context.Servers.ToListAsync();
        }

        public async Task<Server?> GetById(int id)
        {
            return await _context.Servers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Server?> AddServer(ServerDto dto)
        {
            var isExists = await _context.Servers.AnyAsync(x => x.IpAddress == dto.IpAddress);
            if (isExists)
                return null;
            using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                var server = new Server
                {
                    Name = dto.Name,
                    IpAddress = dto.IpAddress,
                    RamGb = dto.RamGb,
                    IsOnline = dto.IsOnline
                };
                await _context.Servers.AddAsync(server);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                return server;
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<Server?> UpdateServer(int id, ServerDto dto)
        {
            var exists = await _context.Servers.FirstOrDefaultAsync(x => x.Id == id);
            if (exists == null)
                return null;


            var isMatch = await _context.Servers
                    .AnyAsync(x => x.IpAddress == dto.IpAddress && x.Id != id);
            if (isMatch)
                return null;
            using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                exists.Name = dto.Name;
                exists.IpAddress = dto.IpAddress;
                exists.RamGb = dto.RamGb;
                exists.IsOnline = dto.IsOnline;
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                return exists;
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<Server?> DeleteServer(int id)
        {
            var server = await _context.Servers.FirstOrDefaultAsync(x => x.Id == id);
            if (server == null)
                return null;
            using var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Servers.Remove(server);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return server;
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}