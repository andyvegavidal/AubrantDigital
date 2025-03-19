using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.Enums;
using System.Diagnostics;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts(
            [FromQuery] SortBy sortBy = SortBy.Name,
            [FromQuery] SortOrder sortOrder = SortOrder.Asc, 
            [FromQuery] int take = 5, 
            [FromQuery] int skip = 0
            )
        {
            var transactionId = Guid.NewGuid().ToString();
            var stopwatch = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation($"[Transaction: {transactionId}] Fetching products with SortBy: {sortBy}, SortOrder: {sortOrder}, Take: {take}, Skip: {skip}");

                var products = _productService.GetProducts(sortBy, sortOrder, take, skip);

                if (products == null || !products.Any())
                {
                    stopwatch.Stop();
                    _logger.LogInformation($"[Transaction: {transactionId}] No products found. Time taken: {stopwatch.ElapsedMilliseconds} ms.");
                    return NotFound(new { message = "No products available." });
                }
                stopwatch.Stop();
                _logger.LogInformation($"[Transaction: {transactionId}] Process ended without issues. Time taken: {stopwatch.ElapsedMilliseconds} ms.");
                return Ok(products);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError($"[Transaction: {transactionId}] An unexpected error occurred. Time taken: {stopwatch.ElapsedMilliseconds} ms. Error: {ex.Message}");
                return StatusCode(500, new { error = "An internal server error occurred. Please try again later." });
            }
        }

    }
}
