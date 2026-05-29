using System.ComponentModel.DataAnnotations;

namespace Day_1_DOT_NET_MVC.Models
{
    //Generate ProductModel with Id, Name, Price, Category fields
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Required Product Name")]
        public string? ProductName { get; set; }
        
        [Required(ErrorMessage = "Required Price")]
        [Range(1000, 100000, ErrorMessage = "Price must between 1000 to 100000 Dollars")]
         public double Price { get; set; }

        [Required(ErrorMessage = "Required Catgory Name of Product")]
        public string? Category { get; set; }
    }

    public class ProductRepo
    {
        public static List<Product> _Product = new List<Product>
        {
            new Product { Id = 1, ProductName = "iPhone 15 Pro Max", Price = 1199.00,
                Category = "Electronics" },
            new Product { Id = 2, ProductName = "Rolex Submariner Date", Price = 10250.00, Category = "Watches" },
            new Product { Id = 3, ProductName = "Louis Vuitton Neverfull MM", Price = 2030.00, Category = "Luxury Bags" }
        };


        //Get All Product 
        public static List<Product> GetAllProducts() => _Product;

        //Get Product By Id
        public static Product? GetProductById(int id)
        {
            Product? product = _Product.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return new Product
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Category = product.Category
                };
            }
            return null;
        }

        //Add Product in to Product Class
        public static bool CreateProduct(Product product)
        {
            Product? checkProduct = _Product.FirstOrDefault(p => p.ProductName == product.ProductName && p.Price == product.Price && p.Category == product.Category);
            if (checkProduct != null)
                return false;
            product.Id = _Product.Count + 1;
            _Product.Add(product);
            return true;
        }

        //Update Product details
        public static void UpdateProduct(int id,Product product)
        {
            Product? ExistsProduct = _Product.FirstOrDefault(p => p.Id == id);
            if (ExistsProduct == null)
                return;

            ExistsProduct.ProductName = product.ProductName;
            ExistsProduct.Price = product.Price;
            ExistsProduct.Category = product.Category;
        }

        //Delete Product by id  
        public static bool DeleteProduct(int id)
        {
            Product? Exists = _Product.FirstOrDefault(p => p.Id == id);
            if (Exists == null) return false;
            _Product.Remove(Exists);
            return true;
        }
    }
}
