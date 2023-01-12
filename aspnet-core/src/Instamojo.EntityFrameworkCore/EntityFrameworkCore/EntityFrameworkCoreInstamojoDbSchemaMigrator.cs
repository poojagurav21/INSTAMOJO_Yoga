using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Instamojo.Data;
using Volo.Abp.DependencyInjection;

namespace Instamojo.EntityFrameworkCore;

public class EntityFrameworkCoreInstamojoDbSchemaMigrator
    : IInstamojoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreInstamojoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the InstamojoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<InstamojoDbContext>()
            .Database
            .MigrateAsync();
    }
}
