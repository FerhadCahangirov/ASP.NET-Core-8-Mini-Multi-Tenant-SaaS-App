namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services.DTOs
{
    /// <summary>
    /// Represents a request to create a new product, including its name and description.
    /// </summary>
    public record CreateProductRequest
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
