using Day_26_DI_Testing_in_Dot_NET_Core.Data;
using Day_26_DI_Testing_in_Dot_NET_Core.Dtos;
using Day_26_DI_Testing_in_Dot_NET_Core.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Repositories
{
    public class VendorRepository(AppDbContext _context, ILogger<VendorRepository> _logger) : IVendorRepository
    {
        public async Task<List<VendorResponseDto>> GetallVendorsAsync()
        {
            _logger.LogInformation("Querying Database for all active vendor");

            var listOfVendors = await _context.Vendors.Where(v => !v.IsDeleted).ToListAsync();
            var vendors = VendorMapper.ToDtoList(listOfVendors);
            return vendors;
        }

        public async Task<VendorResponseDto?> GetVendroByIdAsync(int id)
        {
            _logger.LogInformation("Querying database for active vendor Id {Id}", id);
            var getVendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id && !v.IsDeleted);
            if (getVendor == null)
            {
                _logger.LogWarning("Vendor Id {Id} not found in database", id);
                return null;
            }
            return VendorMapper.ToDto(getVendor);
        }

        public async Task<VendorResponseDto> CreateVendorAsync(VendorRequestDto dto)
        {
            var vendor = VendorMapper.ToVendor(dto);
            _logger.LogInformation("Saving a new Vendor {Name} to database.", dto.BusinessName);

            using var trans = await _context.Database.BeginTransactionAsync();
            await _context.Vendors.AddAsync(vendor);
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Vendor {Name} saving with Id {Id}", vendor.BusinessName, vendor.Id);
            return VendorMapper.ToDto(vendor);
        }

        public async Task<VendorResponseDto?> UpdateVendorAsync(int id, VendorRequestDto dto)
        {
            _logger.LogInformation("Querying database to update Vendor with Id {Id}", id);

            var getVendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id);
            if (getVendor == null)
            {
                _logger.LogWarning("Vendor Id {Id} not found in database", id);
                return null;
            }
            using var trans = await _context.Database.BeginTransactionAsync();
            getVendor.BusinessName = dto.BusinessName;
            getVendor.TaxId = dto.TaxId;
            getVendor.ContactEmail = dto.ContactEmail;
            getVendor.CreditLimit = dto.CreditLimit;
            getVendor.PaymentTerms = dto.PaymentTerms;

            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Vendor Id {Id} Updated Successfully", getVendor.Id);
            return VendorMapper.ToDto(getVendor);
        }

        public async Task<bool> DeleteVendorAsync(int id)
        {
            var getVendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id);
            if (getVendor == null)
            {
                _logger.LogWarning("Vendor Id {Id} not found in database", id);
                return false;
            }
            using var trans = await _context.Database.BeginTransactionAsync();
            getVendor.IsDeleted = true;
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Vendor Id {Id} marked as deleted in database.", getVendor.Id);
            return true;
        }
    }
}