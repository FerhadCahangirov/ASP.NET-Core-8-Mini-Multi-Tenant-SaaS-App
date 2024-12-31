using ASP.NET_Core_Multi_Tenant_SaaS_App.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Context
{
    /// <summary>
    /// Represents the database context for managing tenant data in the system.
    /// </summary>
    public class TenantDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of tenants in the database.
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }
    }

}

