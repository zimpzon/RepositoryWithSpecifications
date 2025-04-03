using Repo.Public.DTO;
using Repo.Public.Specs;

namespace Repo.Public.Repos
{
	public interface IJobRepo
	{
        Task<IEnumerable<JobDto>> List(IJobSpec jobSpec);
        Task<long> Save(JobDto jobDto);
    }
}
