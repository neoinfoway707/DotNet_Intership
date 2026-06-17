namespace Day_25_CRUD_Operations_with_Repository_Pattern.Const
{
    public class ProductRoute
    {
        public const string basic = "api";
        public class Prodcut
        {
            public const string GetAllProducts = basic + "/Products";
            public const string GetProductById = basic + "/Products/{id:int:min(1)}";
            public const string CreateProduct = basic + "/Products";
            public const string UpdateProduct = basic + "/Products/{id:int:min(1)}";
            public const string DeleteProduct = basic + "/Products/{id:int:min(1)}";
        }
    }
}
