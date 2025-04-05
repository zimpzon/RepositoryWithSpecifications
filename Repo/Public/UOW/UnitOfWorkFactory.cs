using Repo.Internal.DomainContext;
using Repo.Internal.Uow;

namespace Repo.Public.UOW
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IDbContextFactory _contextFactory;

		public UnitOfWorkFactory(IDbContextFactory contextFactory)
		{
            _contextFactory = contextFactory;
        }

        public IUnitOfWork CreateUnitOfWork()
		{
			var domainContext = _contextFactory.CreateDbContext();
			return new UnitOfWork(domainContext);
		}
	}
}
