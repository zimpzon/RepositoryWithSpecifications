using Repo.Internal.DomainContext;
using Repo.Internal.Entities;

namespace Repo.Public.Specs
{
	public interface IJobSpec
	{
		internal IQueryable<Job> Execute(DbDomainContext context);
	}
}
