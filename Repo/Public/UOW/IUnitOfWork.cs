using Repo.Internal.DomainContext;

namespace Repo.Public.UOW
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();
		void Cancel();

		// Context should be an abstraction so IUnitOfWork doesn't depend on EntityFramework.
		internal DbDomainContext Context { get; }
	}
}
