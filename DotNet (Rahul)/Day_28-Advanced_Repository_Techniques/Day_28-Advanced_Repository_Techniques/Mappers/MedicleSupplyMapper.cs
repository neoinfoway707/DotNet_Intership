using Day_28_Advanced_Repository_Techniques.Dtos;
using Day_28_Advanced_Repository_Techniques.Models;

namespace Day_28_Advanced_Repository_Techniques.Mappers
{
    public static class MedicleSupplyMapper
    {
        public static MedicleSupplyResponseDto ToDto(MedicleSupply medicleSupply)
        {
            return new MedicleSupplyResponseDto
            {
                Id = medicleSupply.Id,
                ItemCode = medicleSupply.ItemCode,
                ItemName = medicleSupply.ItemName,
                Category = medicleSupply.Category,
                UnitPrice = medicleSupply.UnitPrice,
                QuantityInStock = medicleSupply.QuantityInStock,
                ExpiryDate = medicleSupply.ExpiryDate
            };
        }

        public static List<MedicleSupplyResponseDto> ToDtoList(List<MedicleSupply> medicleSupplies)
        {
            return medicleSupplies.Select(t => ToDto(t)).ToList();
        }

        public static MedicleSupply ToMedicleSupply(MedicleSupplyRequestDto requestDto)
        {
            return new MedicleSupply
            {
                ItemCode = requestDto.ItemCode,
                ItemName = requestDto.ItemName,
                Category = requestDto.Category,
                UnitPrice = requestDto.UnitPrice,
                QuantityInStock = requestDto.QuantityInStock,
                ExpiryDate = requestDto.ExpiryDate
            };
        }
    }
}