using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Instamojo.Data;

/* This is used if database provider does't define
 * IInstamojoDbSchemaMigrator implementation.
 */
public class NullInstamojoDbSchemaMigrator : IInstamojoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
