namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Const
{
    public class MedicleSupplyRoute
    {
        public const string basic = "api";
        public class MedicleSupply
        {
            public const string GetAllMedicleSupplys = basic + "/MedicleSupplies";
            public const string GetMedicleSupplyByID = basic + "/MedicleSupplies/{id:int:min(1)}";
            public const string CreateMedicleSupply = basic + "/MedicleSupplies";
            public const string UpdateMedicleSupply = basic + "/MedicleSupplies/{id:int:min(1)}";
            public const string DeleteMedicleSupply = basic + "/MedicleSupplies/{id:int:min(1)}";
        }
    }
}
