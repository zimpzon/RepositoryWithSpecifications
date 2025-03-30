using Repo.Mappers;
using Repo.Public.DTO;
using Repo.Public.Specs;
using Repo.Public.UOW;

namespace Repo.Public.Repos
{
	public class JobRepo : IJobRepo
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;

		public JobRepo(IUnitOfWorkFactory unitOfWorkFactory)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
		}

		public IEnumerable<JobDto> All(IJobSpec jobSpec, IUnitOfWork? unitOfWork = null)
		{
			unitOfWork = unitOfWork ?? _unitOfWorkFactory.CreateUnitOfWork();
			var job = jobSpec.Execute(unitOfWork.Context).FirstOrDefault();
			if (job is null)
				return [];

			var jobDto = EntityToDtoMappers.ToDto(job);
			return [jobDto];
		}
	}
}
