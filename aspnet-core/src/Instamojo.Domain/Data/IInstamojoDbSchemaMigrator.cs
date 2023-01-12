using System.Threading.Tasks;

namespace Instamojo.Data;

public interface IInstamojoDbSchemaMigrator
{
    Task MigrateAsync();
}
