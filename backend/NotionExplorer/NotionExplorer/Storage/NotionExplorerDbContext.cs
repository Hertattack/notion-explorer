using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace NotionExplorer.Storage
{
    [DbConfigurationType(typeof(StorageConfiguration))]
    public class NotionExplorerDbContext : DbContext
    {
    }
}