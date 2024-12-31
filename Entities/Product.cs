using ASP.NET_Core_Multi_Tenant_SaaS_App.Services;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Entities
{
    /// <summary>
    /// Represents a product within the system, implementing the IMustHaveTenant interface.
    /// </summary>
    public sealed class Product : IMustHaveTenant
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets or sets the TenantId associated with the product.
        /// </summary>
        public string TenantId { get; set; }
    }

}
