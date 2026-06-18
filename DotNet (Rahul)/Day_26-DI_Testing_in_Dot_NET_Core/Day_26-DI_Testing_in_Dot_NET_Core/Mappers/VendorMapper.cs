using Day_26_DI_Testing_in_Dot_NET_Core.Dtos;
using Day_26_DI_Testing_in_Dot_NET_Core.Models;
using System.Numerics;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Mappers
{
    public static class VendorMapper
    {
        public static VendorResponseDto ToDto(Vendor vendor)
        {
            return new VendorResponseDto
            {
                Id = vendor.Id,
                BusinessName = vendor.BusinessName,
                TaxId = vendor.TaxId,
                ContactEmail = vendor.ContactEmail,
                CreditLimit = vendor.CreditLimit,
                PaymentTerms = vendor.PaymentTerms,
                OnboardedAt = vendor.OnboardedAt
            };
        }

        public static List<VendorResponseDto> ToDtoList(List<Vendor> vendors)
        {
            return vendors.Select(v => ToDto(v)).ToList();
        }

        public static Vendor ToVendor(VendorRequestDto requestDto)
        {
            return new Vendor
            {
                BusinessName = requestDto.BusinessName,
                TaxId = requestDto.TaxId,
                ContactEmail = requestDto.ContactEmail,
                CreditLimit = requestDto.CreditLimit,
                PaymentTerms = requestDto.PaymentTerms
            };
        }
    }
}
