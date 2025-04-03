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

		public IEnumerable<JobDto> List(IJobSpec jobSpec)
		{
			using var context = _dbContextFactory.CreateDbContext();

			var job = jobSpec.Execute(context).FirstOrDefault();
			return job is null ? [] : [EntityToDtoMappers.ToDto(job)];
		}
	}
}
