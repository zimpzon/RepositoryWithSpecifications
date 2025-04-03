using Microsoft.EntityFrameworkCore;
using Repo.Internal.DomainContext;
using Repo.Internal.Entities;
using Repo.Public.Specs.JobSpecs;

namespace Repo.Public.Specs.JobSpec
{
	public class JobSpecGetById(long id, ChildrenInclude childrenInclude = ChildrenInclude.None) : IJobSpec
	{
        IQueryable<Job> IJobSpec.Execute(DbDomainContext context)
        {
            var query = context.Jobs.
                AsNoTracking().
                AsSplitQuery().
                Where(j => j.Id == id);

            query = JobSpecIncludeHelper.Include(query, childrenInclude);
            return query;
        }
    }
}
