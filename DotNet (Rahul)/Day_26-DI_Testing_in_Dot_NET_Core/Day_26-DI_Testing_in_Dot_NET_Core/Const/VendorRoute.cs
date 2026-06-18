namespace Day_26_DI_Testing_in_Dot_NET_Core.Const
{
    public class VendorRoute
    {
        public const string basic = "api";
        public class Vendor
        {
            public const string GetAllVendors = basic + "/Vendors";
            public const string GetVendorById = basic + "/Vendors/{id:int:min(1)}";
            public const string CreateVendor = basic + "/Vendors";
            public const string UpdateVendor = basic + "/Vendors/{id:int:min(1)}";
            public const string DeleteVendor = basic + "/Vendors/{id:int:min(1)}";
        }
    }
}
