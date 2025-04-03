using Microsoft.EntityFrameworkCore;
using Repo.Internal.Entities;

namespace Repo.Public.Specs.JobSpecs
{
    internal static class JobSpecIncludeHelper
    {
        public static IQueryable<Job> Include(IQueryable<Job> query, ChildrenInclude childrenInclude)
        {
            if (childrenInclude == ChildrenInclude.None)
                return query;

            if (childrenInclude == ChildrenInclude.Flat)
            {
                // 1:1 relations only. Currently none.
            }
            else if (childrenInclude == ChildrenInclude.Immediate)
            {
                // Alle immediate (level 1) includes.
                query.Include(q => q.JobTasks).ThenInclude(jt => jt.Employees);
                query.Include(q => q.Employees);
            }
            else if (childrenInclude != ChildrenInclude.Nested)
            {
                // Full tree structure of children.
            }
            return query;
        }
    }
}
