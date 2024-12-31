namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services
{
    /// <summary>
    /// Interface that requires implementing classes to have a TenantId property.
    /// </summary>
    public interface IMustHaveTenant
    {
        /// <summary>
        /// Gets or sets the TenantId for the implementing class.
        /// </summary>
        string TenantId { get; set; }
    }
}
