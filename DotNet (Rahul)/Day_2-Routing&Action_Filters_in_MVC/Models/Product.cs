namespace Day_2_Routing_Action_Filters_in_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
    }
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99m },
            new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 499.99m },
            new Product { Id = 3, Name = "Table", Category = "Furniture", Price = 199.99m },
            new Product { Id = 4, Name = "Chair", Category = "Furniture", Price = 89.99m }
        };
        public static List<Product> GetAllProducts()
        {
            return _products;
        }

        public static void AddProduct(Product product)
        {
            if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            _products.Add(product);
            return;
        }

    }
}
