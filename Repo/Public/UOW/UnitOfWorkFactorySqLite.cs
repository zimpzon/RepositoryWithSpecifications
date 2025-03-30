using Microsoft.EntityFrameworkCore;
using Repo.Internal.DomainContext;
using Repo.Internal.Uow;

namespace Repo.Public.UOW
{
	public class UnitOfWorkFactorySqLite : IUnitOfWorkFactory
	{
		public IUnitOfWork CreateUnitOfWork()
		{
			var optionsBuilder = new DbContextOptionsBuilder<DbDomainContext>();
			optionsBuilder.UseSqlite("Data Source=sqLite.db");

			var domainContext = new DbDomainContext(optionsBuilder.Options);
			domainContext.Database.EnsureCreated();

			return new UnitOfWork(domainContext);
		}
	}
}
