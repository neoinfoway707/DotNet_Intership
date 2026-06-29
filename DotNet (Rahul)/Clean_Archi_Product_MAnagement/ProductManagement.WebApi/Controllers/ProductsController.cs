using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Common.Dtos;
using ProductManagement.Application.Features.Products.Command.DeleteProduct;
using ProductManagement.Application.Features.Products.Query.GetAllProducts;
using ProductManagement.Application.Features.Products.Query.GetProdutById;
using ProductManagement.Application.Interfaces.Services;
using ProductManagement.WebApi.Mappers;
using ProductManagement.WebApi.Models;
using ProductManagement.WebApi.Wrapper;

namespace ProductManagement.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator _mediator, IFileStorageService _fileStorage, ILogger<ProductsController> _logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            _logger.LogInformation("Fetching all active Product data.");
            var listOfProducts = await _mediator.Send(new GetAllProductsQuery());
            var wrapperResponse = new ProductResponse<List<ProductResponseDto>>(listOfProducts, "All Product Data Retrieved successfully.");
            return Ok(wrapperResponse);
        }
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product == null)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return NotFound(new ProductResponse<ProductResponseDto>($"The requested product with ID {id} was not found."));
            }
            _logger.LogInformation("Fetching Product with Id {Id}", id);
            return Ok(new ProductResponse<ProductResponseDto>(product, "Data Retrieved Successfully."));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProductAsync([FromForm] CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Product Model does not validate.");
                return BadRequest(ModelState);
            }
            string path = string.Empty;
            try
            {
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    using (var stream = request.ImageFile.OpenReadStream())
                    {
                        path = await _fileStorage.SaveFileAsync(stream, request.ImageFile.FileName);
                    }
                }
                var command = ApiMapper.ToCreateCommand(request, path);
                var result = await _mediator.Send(command);
                
                if (result < 1)
                    return BadRequest("Failed to create a new Product.");

                var wrapperResponse = new ProductResponse<int>(result, "New product created successfully.");
                _logger.LogInformation("Product '{Name}' created successfully with ID {Id}.", request.Name, result);
                return CreatedAtAction(nameof(GetProductByIdAsync), new { id = result }, wrapperResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "File validation failed during product creation.");
                return BadRequest(new ProductResponse<bool>(false, ex.Message));
            }
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] UpdateProductRequest request)
        {
            if (id != request.Id)
            {
                _logger.LogWarning("Product with Id {Id} Not match to data.", id);
                return BadRequest(new ProductResponse<ProductResponseDto>("Product ID mismatch between route and request body."));
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Product Model does not validate.");
                return BadRequest(ModelState);
            }

            string? path = null;
            try
            {
                if (request.ImageFile != null && request.ImageFile.Length > 0)
                {
                    using (var stream = request.ImageFile.OpenReadStream())
                    {
                        path = await _fileStorage.SaveFileAsync(stream, request.ImageFile.FileName);
                    }
                }

                var command = ApiMapper.ToUpdateCommand(request, path);
                var update = await _mediator.Send(command);
                if (!update)
                {
                    _logger.LogWarning("Product with Id {Id} not found.", id);
                    return NotFound(new ProductResponse<ProductResponseDto>($"Give Product with Id {id} Not Found."));
                }
                _logger.LogInformation("Product '{Name}' with ID {Id} updated successfully.", request.Name, id); return Ok(new ProductResponse<bool>(true, "Product details updated successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "File validation failed during product creation.");
                return BadRequest(new ProductResponse<bool>(false, ex.Message));
            }
        }
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            var delete = await _mediator.Send(command);
            if (!delete)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return NotFound(new ProductResponse<ProductResponseDto>($"Give Product with Id {id} Not Found."));
            }
            _logger.LogInformation("Product with Id {Id} is marked as Deleted at Database side.", id);
            return Ok(new ProductResponse<bool>(true, "Product deleted successfully."));
        }
    }
}