using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Data;
using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Dtos;
using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Repositories
{
    public class MedicleSupplyRepository(AppDbContext _context, ILogger<MedicleSupplyRepository> _logger) : IMedicleSupplyRepository
    {
        public async Task<(List<MedicleSupplyResponseDto> Items, int TotalCount)> GetallMedicleSupplysAsync(MedicleSupplyQueryParams queryParams)
        {
            _logger.LogInformation("Querying Database for all active medicleSupply");

            var query = _context.MedicalSupplies.Where(x => x.IsActive).AsQueryable();

            //filtering 
            if (!string.IsNullOrEmpty(queryParams.Category))
                query = query.Where(x => x.Category == queryParams.Category);
            if (queryParams.MinPrice.HasValue)
                query = query.Where(x => x.UnitPrice >= queryParams.MinPrice.Value);
            if (queryParams.MaxPrice.HasValue)
                query = query.Where(x => x.UnitPrice <= queryParams.MaxPrice.Value);

            //sorting
            if (!string.IsNullOrEmpty(queryParams.SortBy))
            {
                query = queryParams.SortBy.ToLower() switch
                {
                    "unitprice" => queryParams.SortOrder == "desc" 
                        ? query.OrderByDescending(x => x.UnitPrice) : query.OrderBy(x => x.UnitPrice),
                    "expirydate" => queryParams.SortOrder == "desc" 
                        ? query.OrderByDescending(x => x.ExpiryDate) : query.OrderBy(x => x.ExpiryDate),
                    "quantityinstock" => queryParams.SortOrder == "desc" 
                        ? query.OrderByDescending(x => x.QuantityInStock) 
                        : query.OrderBy(x => x.QuantityInStock),
                    _ => query.OrderBy(x => x.Id)
                };
            }
            var totalCount = await query.CountAsync();

            //Pagination
            var items = await query.Skip((queryParams.Pages - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize).ToListAsync();

            _logger.LogInformation("Retrieved {Count} of {Total} records", items.Count, totalCount);
            return (MedicleSupplyMapper.ToDtoList(items), totalCount);
        }

        public async Task<MedicleSupplyResponseDto?> GetMedicleSupplyIdAsync(int id)
        {
            _logger.LogInformation("Querying database for active medicleSupply Id {Id}", id);
            var getMedicleSupply = await _context.MedicalSupplies.FirstOrDefaultAsync(v => v.Id == id && v.IsActive);
            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return null;
            }
            return MedicleSupplyMapper.ToDto(getMedicleSupply);
        }

        public async Task<MedicleSupplyResponseDto> CreateMedicleSupplyAsync(MedicleSupplyRequestDto dto)
        {
            var medicleSupply = MedicleSupplyMapper.ToMedicleSupply(dto);
            _logger.LogInformation("Saving a new MedicleSupply {Name} to database.", dto.ItemName);

            using var trans = await _context.Database.BeginTransactionAsync();
            await _context.MedicalSupplies.AddAsync(medicleSupply);
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("MedicleSupply {Name} saving with Id {Id}", medicleSupply.ItemName, medicleSupply.Id);
            return MedicleSupplyMapper.ToDto(medicleSupply);
        }

        public async Task<MedicleSupplyResponseDto?> UpdateMedicleSupplyAsync(int id, MedicleSupplyRequestDto medicleSupply)
        {
            _logger.LogInformation("Querying database to update MedicleSupply with Id {Id}", id);

            var getMedicleSupply = await _context.MedicalSupplies.FirstOrDefaultAsync(v => v.Id == id && v.IsActive);
            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return null;
            }
            using var trans = await _context.Database.BeginTransactionAsync();


            getMedicleSupply.ItemCode = medicleSupply.ItemCode;
            getMedicleSupply.ItemName = medicleSupply.ItemName;
            getMedicleSupply.Category = medicleSupply.Category;
            getMedicleSupply.UnitPrice = medicleSupply.UnitPrice;
            getMedicleSupply.QuantityInStock = medicleSupply.QuantityInStock;
            getMedicleSupply.ExpiryDate = medicleSupply.ExpiryDate;

            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("MedicleSupply Id {Id} Updated Successfully", getMedicleSupply.Id);
            return MedicleSupplyMapper.ToDto(getMedicleSupply);
        }

        public async Task<bool> DeleteMedicleSupplyAsync(int id)
        {
            var getMedicleSupply = await _context.MedicalSupplies.FirstOrDefaultAsync(v => v.Id == id && v.IsActive);
            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return false;
            }
            using var trans = await _context.Database.BeginTransactionAsync();
            getMedicleSupply.IsActive = false;
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("MedicleSupply Id {Id} marked as deleted in database.", getMedicleSupply.Id);
            return true;
        }
    }
}