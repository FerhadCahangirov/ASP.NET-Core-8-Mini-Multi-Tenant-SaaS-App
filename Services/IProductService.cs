using ASP.NET_Core_Multi_Tenant_SaaS_App.Entities;
using ASP.NET_Core_Multi_Tenant_SaaS_App.Services.DTOs;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services
{
    /// <summary>
    /// Interface for managing products within the system.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Creates a new product based on the provided request data.
        /// </summary>
        /// <param name="request">The data required to create a new product.</param>
        /// <returns>The newly created product.</returns>
        Product CreateProduct(CreateProductRequest request);

        /// <summary>
        /// Deletes a product by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the product to delete.</param>
        /// <returns>True if the product was successfully deleted; otherwise, false.</returns>
        bool DeleteProduct(int id);
    }

}
