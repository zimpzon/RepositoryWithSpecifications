using Repo.Internal.DomainContext;
using Repo.Public.UOW;

namespace Repo.Internal.Uow
{
	internal class UnitOfWork : IUnitOfWork
	{
		private readonly DbDomainContext _domainContext;

		public UnitOfWork(DbDomainContext domainContext)
		{
			ArgumentNullException.ThrowIfNull(domainContext, nameof(domainContext));

			_domainContext = domainContext;
			_domainContext.Database.BeginTransaction();
		}

		DbDomainContext IUnitOfWork.Context
			=> _domainContext;

		void IUnitOfWork.Cancel()
		{
			_domainContext.Database.RollbackTransaction();
		}

		void IUnitOfWork.Save()
		{
			_domainContext.SaveChanges();
			_domainContext.Database.CommitTransaction();
		}

		void IDisposable.Dispose()
		{
			_domainContext.Dispose();
		}
	}
}
