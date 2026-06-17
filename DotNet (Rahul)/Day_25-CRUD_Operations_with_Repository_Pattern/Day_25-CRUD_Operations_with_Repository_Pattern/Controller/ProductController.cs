using Day_25_CRUD_Operations_with_Repository_Pattern.Const;
using Day_25_CRUD_Operations_with_Repository_Pattern.Dtos;
using Day_25_CRUD_Operations_with_Repository_Pattern.Repository;
using Day_25_CRUD_Operations_with_Repository_Pattern.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Controller
{
    [ApiController]
    public class ProductController(IProductRepository _repo, ILogger<ProductController> _logger) : ControllerBase
    {
        [HttpGet(ProductRoute.Prodcut.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts()
        {
            var listOfProducts = await _repo.GetAllProductsAsync();
            var wrapperResponse = new ProductResponse<List<ProductResponseDto>>(listOfProducts, "All Product Data Retrieved successfully.");
            _logger.LogInformation("Fetching all active Product data.");
            return Ok(wrapperResponse);
        }

        [HttpGet(ProductRoute.Prodcut.GetProductById)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var getProduct = await _repo.GetProductByIdAsync(id);
            if (getProduct == null)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return NotFound(new ProductResponse<ProductResponseDto>($"Product with Id {id} not found."));
            }
            _logger.LogInformation("Fetching Product with Id {Id}", id);
            return Ok(new ProductResponse<ProductResponseDto>(getProduct, "Data Retrieved Successfully."));
        }
        [HttpPost(ProductRoute.Prodcut.CreateProduct)]
        public async Task<IActionResult> CreatrProduct(ProductRequestDto requestDto)
        {
            var addProduct = await _repo.CreateProductAsync(requestDto);
            var wrapperResponse = new ProductResponse<ProductResponseDto>(addProduct, "New Product Created.");
            _logger.LogInformation("Product {Name} created with Id {Id}.", addProduct.Name, addProduct.Id);
            return CreatedAtAction(nameof(GetProductById), new { Id = addProduct.Id }, wrapperResponse);
        }

        [HttpPut(ProductRoute.Prodcut.UpdateProduct)]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequestDto requestDto)
        {
            var updateProduct = await _repo.UpdateProductAsync(id, requestDto);
            if (updateProduct == null)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return NotFound(new ProductResponse<ProductResponseDto>($"Product with Id {id} not found."));
            }
            _logger.LogInformation("Product {Name} Updated with Id {Id}", updateProduct.Name, updateProduct.Id);
            return Ok(new ProductResponse<ProductResponseDto>(updateProduct, "Product Data Updated Successfully."));
        }

        [HttpDelete(ProductRoute.Prodcut.DeleteProduct)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleteProduct = await _repo.DeleteProductAsync(id);
            if (!deleteProduct)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return NotFound(new ProductResponse<ProductResponseDto>($"Product with Id {id} not found."));
            }
            _logger.LogInformation("Product with Id {Id} is marked as Deleted at Database side.", id);
            return NoContent();
        }
    }
}