using V.SMART.Shared.Data;
using V.SMART.Shared.Services.MultiCompanyService;
using Microsoft.EntityFrameworkCore;

public class TenantDbContextFactory : ITenantDbContextFactory
{
    private readonly ITenantProvider _tenantProvider;

    public TenantDbContextFactory(ITenantProvider tenantProvider)
    {
        _tenantProvider = tenantProvider;
    }

    //public ApplicationDbContext CreateDbContext()
    //{
    //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

    //    optionsBuilder.UseSqlServer(
    //        _tenantProvider.GetCurrentTenant().ConnectionString,
    //        sqlOptions =>
    //        {
    //            sqlOptions.CommandTimeout(60); // 👈 set timeout to 60 seconds
    //        });

    //    return new ApplicationDbContext(optionsBuilder.Options);
    //}

    public ApplicationDbContext CreateDbContext()
    {
        var tenant = _tenantProvider.GetCurrentTenant();

        if (tenant == null)
            throw new InvalidOperationException("Current tenant was not found.");

        if (string.IsNullOrWhiteSpace(tenant.ConnectionString))
            throw new InvalidOperationException("Tenant connection string is missing.");

        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
            tenant.ConnectionString,
            sqlOptions =>
            {
                sqlOptions.CommandTimeout(60);
            });

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

