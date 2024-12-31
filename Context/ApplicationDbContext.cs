using ASP.NET_Core_Multi_Tenant_SaaS_App.Entities;
using ASP.NET_Core_Multi_Tenant_SaaS_App.Services;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Context
{
    /// <summary>
    /// Represents the application's database context, providing access to entities and data operations,
    /// and ensuring data is filtered and saved based on the current tenant.
    /// </summary>
    public sealed class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;

        /// <summary>
        /// Gets or sets the current tenant's identifier.
        /// </summary>
        public string CurrentTenantId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        /// <param name="currentTenantService">The service used to resolve the current tenant's identifier.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenantService currentTenantService) : base(options)
        {
            _currentTenantService = currentTenantService;
            CurrentTenantId = _currentTenantService.TenantId;
        }

        /// <summary>
        /// Gets or sets the collection of products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the collection of tenants in the database.
        /// </summary>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Configures the model for the database context, including tenant-based query filtering.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply a global query filter to ensure that products are only accessible by the current tenant
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.TenantId == CurrentTenantId);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Saves changes made to the database, ensuring that entities implement <see cref="IMustHaveTenant"/> 
        /// are assigned the current tenant identifier before saving.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Modified:
                        // Ensure the TenantId is set for modified entities
                        entry.Entity.TenantId = CurrentTenantId;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }

}