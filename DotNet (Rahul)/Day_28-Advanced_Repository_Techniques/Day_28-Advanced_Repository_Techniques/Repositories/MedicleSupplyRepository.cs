using Day_28_Advanced_Repository_Techniques.Data;
using Day_28_Advanced_Repository_Techniques.Dtos;
using Day_28_Advanced_Repository_Techniques.Mappers;
using Day_28_Advanced_Repository_Techniques.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data;

namespace Day_28_Advanced_Repository_Techniques.Repositories
{
    public class MedicleSupplyRepository(AppDbContext _context, ILogger<MedicleSupplyRepository> _logger) : IMedicleSupplyRepository
    {
        public async Task<(List<MedicleSupplyResponseDto> Items, int TotalCount)> GetallMedicleSupplysAsync(MedicleSupplyQueryParams queryParams)
        {
            _logger.LogInformation("Querying Database for all active medicleSupply");

            var totalCountParam = new SqlParameter("@Totalcount", SqlDbType.Int) { Direction = ParameterDirection.Output };

            var items = await _context.MedicalSupplies
                .FromSqlRaw("EXEC GetMedicleSuppliesItems @Category, @MinPrice, @MaxPrice, @SortOrder, @SortBy, @PageNumber, @PageSize, @TotalCount OUTPUT",
                    new SqlParameter("@Category", (object?)queryParams.Category ?? DBNull.Value),
                    new SqlParameter("@MinPrice", (object?)queryParams.MinPrice ?? DBNull.Value),
                    new SqlParameter("@MaxPrice", (object?)queryParams.MaxPrice ?? DBNull.Value),
                    new SqlParameter("@SortBy", (object?)queryParams.SortBy ?? DBNull.Value),
                    new SqlParameter("@SortOrder", (object)queryParams.SortOrder ?? DBNull.Value),
                    new SqlParameter("@PageNumber", queryParams.Pages),
                    new SqlParameter("@PageSize", queryParams.PageSize),
                    totalCountParam
                ).ToListAsync();
            int totalCount = (int)totalCountParam.Value;

            _logger.LogInformation("Retrieved {Count} of {Total} records", items.Count, totalCount);
            return (MedicleSupplyMapper.ToDtoList(items), totalCount);
        }

        public async Task<MedicleSupplyResponseDto?> GetMedicleSupplyIdAsync(int id)
        {
            _logger.LogInformation("Querying database for active medicleSupply Id {Id}", id);

            var getMedicleSupply = await _context.MedicalSupplies
                .FromSqlRaw("EXEC GetMedicleSupplyId @Id", new SqlParameter("@Id", id))
                .AsAsyncEnumerable()
                .FirstOrDefaultAsync();
            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return null;
            }
            return MedicleSupplyMapper.ToDto(getMedicleSupply);
        }

        public async Task<MedicleSupplyResponseDto?> CreateMedicleSupplyAsync(MedicleSupplyRequestDto dto)
        {
            _logger.LogInformation("Saving a new MedicleSupply {Name} to database.", dto.ItemName);
            var parameters = new[]
            {
                new SqlParameter("@ItemCode",dto.ItemCode),
                new SqlParameter("@ItemName",dto.ItemName),
                new SqlParameter("@Category",dto.Category),
                new SqlParameter("@UnitPrice",dto.UnitPrice),
                new SqlParameter("@QuantityInStock",dto.QuantityInStock),
                new SqlParameter("@ExpiryDate",dto.ExpiryDate)
            };
            var medicleSupply = await _context.MedicalSupplies
                .FromSqlRaw("EXEC CreateMedicleSupply @ItemCode, @ItemName, @Category, @UnitPrice, @QuantityInStock, @ExpiryDate", parameters)
                .AsAsyncEnumerable()
                .FirstOrDefaultAsync();

            if (medicleSupply == null)
            {
                _logger.LogWarning("Faield to Create New MedicleSupply Record.");
                return null;
            }
            _logger.LogInformation("MedicleSupply {Name} saving with Id {Id}", medicleSupply.ItemName, medicleSupply.Id);
            return MedicleSupplyMapper.ToDto(medicleSupply);
        }

        public async Task<MedicleSupplyResponseDto?> UpdateMedicleSupplyAsync(int id, MedicleSupplyRequestDto medicleSupply)
        {
            _logger.LogInformation("Querying database to update MedicleSupply with Id {Id}", id);

            var getMedicleSupply = await _context.Database
                .SqlQueryRaw<MedicleSupplyResponseDto>("Select * from MedicalSupplies where Id = @Id AND IsActive = 1",
                new SqlParameter("@Id", id)).FirstOrDefaultAsync();
            //var getMedicleSupply = await _context.MedicalSupplies
            //    .FromSqlRaw("EXEC GetMedicleSupplyId @Id", new SqlParameter("@Id", id))
            //    .AsAsyncEnumerable()
            //    .FirstOrDefaultAsync();

            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return null;
            }

            var parameters = new[]
                       {
                new SqlParameter("@ItemCode",medicleSupply.ItemCode),
                new SqlParameter("@ItemName",medicleSupply.ItemName),
                new SqlParameter("@Category",medicleSupply.Category),
                new SqlParameter("@UnitPrice",medicleSupply.UnitPrice),
                new SqlParameter("@QuantityInStock",medicleSupply.QuantityInStock),
                new SqlParameter("@ExpiryDate",medicleSupply.ExpiryDate),
                new SqlParameter("@Id",getMedicleSupply.Id)
            }; var UpdateMedicleSupply = await _context.MedicalSupplies
                 .FromSqlRaw("EXEC UpdateMedicleSupply @ItemCode, @ItemName, @Category, @UnitPrice, @QuantityInStock, @ExpiryDate, @Id", parameters)
                 .AsAsyncEnumerable()
                 .FirstOrDefaultAsync();

            _logger.LogInformation("MedicleSupply Id {Id} Updated Successfully", UpdateMedicleSupply.Id);
            return MedicleSupplyMapper.ToDto(UpdateMedicleSupply);
        }

        public async Task<bool> DeleteMedicleSupplyAsync(int id)
        {
            var getMedicleSupply = await _context.Database
                .SqlQueryRaw<MedicleSupplyResponseDto>("Select * from MedicalSupplies where Id = @Id AND IsActive = 1",
                new SqlParameter("@Id", id)).FirstOrDefaultAsync();
            //var getMedicleSupply = await _context.MedicalSupplies
            //    .FromSqlRaw("EXEC GetMedicleSupplyId @Id", parameter)
            //    .AsAsyncEnumerable()
            //    .FirstOrDefaultAsync();

            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply Id {Id} not found in database", id);
                return false;
            }
            var parameter = new SqlParameter("@Id", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteMedicleSupply @Id", parameter);

            _logger.LogInformation("MedicleSupply Id {Id} marked as deleted in database.", getMedicleSupply.Id);
            return true;
        }
    }
}