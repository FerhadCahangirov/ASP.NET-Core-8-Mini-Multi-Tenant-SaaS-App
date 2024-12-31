using ASP.NET_Core_Multi_Tenant_SaaS_App.Services;
using ASP.NET_Core_Multi_Tenant_SaaS_App.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Controllers
{
    /// <summary>
    /// Controller for managing products in the system.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The product service used to manage products.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var list = _productService.GetAllProducts();
            return Ok(list);
        }

        /// <summary>
        /// Creates a new product based on the provided request.
        /// </summary>
        /// <param name="request">The request containing the data to create a new product.</param>
        /// <returns>The newly created product.</returns>
        [HttpPost]
        public IActionResult Post(CreateProductRequest request)
        {
            var result = _productService.CreateProduct(request);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a product by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>True if the product was successfully deleted, otherwise false.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }

}
