
using ASP.NET_Core_Multi_Tenant_SaaS_App.Context;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Services
{
    public sealed class CurrentTenantService : ICurrentTenantService
    {
        private readonly TenantDbContext _context;

        public CurrentTenantService(TenantDbContext context)
        {
            _context = context;
        }

        public string? TenantId { get; set ; }

        public async Task<bool> SetTenant(string tenantId)
        {
            var tenantInfo = await _context.Tenants
                .Where(x => x.Id == tenantId)
                .FirstOrDefaultAsync() 
                ?? throw new Exception("Tenant invalid");

            TenantId = tenantInfo.Id;
            return true;
        }
    }
}
