using Microsoft.EntityFrameworkCore;
using Repo.Internal.DomainContext;
using Repo.Mappers;
using Repo.Public.DTO;
using Repo.Public.Specs;

namespace Repo.Public.Repos
{
	public class JobRepo : IJobRepo
	{
		private readonly IDbContextFactory _dbContextFactory;

		public JobRepo(IDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<IEnumerable<JobDto>> List(IJobSpec jobSpec)
		{
			using var context = _dbContextFactory.CreateDbContext();

			var jobs = await jobSpec.Execute(context).ToListAsync();
			return jobs.Select(j => EntityToDtoMappers.ToDto(j));
		}

        public Task<long> Save(JobDto jobDto)
        {
            throw new NotImplementedException();
        }
    }
}
