namespace Repo.Internal.DomainContext
{
    public interface IDbContextFactory
    {
        DbDomainContext CreateDbContext();
    }
}
