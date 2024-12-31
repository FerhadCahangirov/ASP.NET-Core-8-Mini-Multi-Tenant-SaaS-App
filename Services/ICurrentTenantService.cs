namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services
{
    /// <summary>
    /// Interface for managing the current tenant context in an application.
    /// </summary>
    public interface ICurrentTenantService
    {
        /// <summary>
        /// Gets or sets the TenantId for the current tenant.
        /// </summary>
        string? TenantId { get; set; }

        /// <summary>
        /// Sets the TenantId for the current tenant asynchronously.
        /// </summary>
        /// <param name="tenantId">The TenantId to set for the current tenant.</param>
        /// <returns>A task that represents the asynchronous operation, with a boolean result indicating success.</returns>
        public Task<bool> SetTenant(string tenantId);
    }

}
