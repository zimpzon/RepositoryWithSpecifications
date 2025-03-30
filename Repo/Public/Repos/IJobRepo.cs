using Repo.Public.DTO;
using Repo.Public.Specs;
using Repo.Public.UOW;

namespace Repo.Public.Repos
{
	public interface IJobRepo
	{
		IEnumerable<JobDto> All(IJobSpec jobSpec, IUnitOfWork? unitOfWork = null);
	}
}
