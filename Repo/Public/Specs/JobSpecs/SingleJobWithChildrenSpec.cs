using Microsoft.EntityFrameworkCore;
using Repo.Internal.DomainContext;
using Repo.Internal.Entities;

namespace Repo.Public.Specs.JobSpec
{
	public class SingleJobWithChildrenSpec(long id) : IJobSpec
	{
		IQueryable<Job> IJobSpec.Execute(DbDomainContext context)
		{
			var matches = context.Jobs.
				AsNoTracking().
				AsSplitQuery().
				Where(j => j.Id == id).
				Include(j => j.JobTasks).ThenInclude(jt => jt.Employees).
				Include(t => t.Employees);

			return matches;
		}
	}
}
