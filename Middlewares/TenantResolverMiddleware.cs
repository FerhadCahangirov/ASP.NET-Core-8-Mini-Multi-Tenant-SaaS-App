using ASP.NET_Core_Multi_Tenant_SaaS_App.Services;

namespace ASP.NET_Core_Multi_Tenant_SaaS_App.Middlewares
{
    /// <summary>
    /// Middleware for resolving the current tenant based on the incoming HTTP request's headers.
    /// </summary>
    public sealed class TenantResolverMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantResolverMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline to invoke.</param>
        public TenantResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the middleware to resolve the tenant from the request headers and sets it in the current tenant service.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <param name="currentTenantService">The service responsible for setting the current tenant.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, ICurrentTenantService currentTenantService)
        {
            // Try to retrieve the "tenant" value from the request headers
            context.Request.Headers.TryGetValue("tenant", out var tenantFromHeader);

            // If a tenant value is found in the header, set it in the current tenant service
            if (string.IsNullOrEmpty(tenantFromHeader) == false)
            {
                await currentTenantService.SetTenant(tenantFromHeader);
            }

            // Continue with the next middleware in the pipeline
            await _next(context);
        }
    }

}
