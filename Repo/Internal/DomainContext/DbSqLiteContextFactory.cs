using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Repo.Internal.DomainContext
{
    public class DbSqLiteContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<DbDomainContext> _options;
        private readonly DbConnection _keepAlive;

        public DbSqLiteContextFactory()
        {
            _keepAlive = new SqliteConnection("Data source=:memory:");
            _keepAlive.Open();

            _options = new DbContextOptionsBuilder<DbDomainContext>().
                UseSqlite(_keepAlive, (a) => { a.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); }).
                Options;

            using var context = new DbDomainContext(_options);
            context.Database.EnsureCreated();
        }

        public DbDomainContext CreateDbContext()
        {
            return new DbDomainContext(_options);
        }
    }
}
