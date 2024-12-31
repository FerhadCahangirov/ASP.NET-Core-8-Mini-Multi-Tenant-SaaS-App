using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Entities
{
    /// <summary>
    /// Represents a tenant within the system.
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Gets or sets the unique identifier for the tenant.
        /// This property is marked as the primary key and will not be auto-generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the tenant.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

}
