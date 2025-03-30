using Repo.Public.Repos;
using Repo.Public.Specs.JobSpec;
using Repo.Public.UOW;

namespace ArchitectureTest
{
	internal class Program
    {
        static void Main(string[] args)
        {
			// Concrete classes used here would be dependency injected as interfaces.
            // Casting to interfaces here to make it similar to DI.
			// Also, implement all EF Core specific in it's own library.

			var uowFactory = new UnitOfWorkFactorySqLite() as IUnitOfWorkFactory;

			using var uow = uowFactory.CreateUnitOfWork();

			var jobRepo = new JobRepo(uowFactory) as IJobRepo;

			var singleJobWithChildrenSpec = new SingleJobWithChildrenSpec(id: 1);
			var jobWithChildren = jobRepo.All(singleJobWithChildrenSpec, uow).SingleOrDefault();

			uow.Cancel();

			Console.WriteLine("Hello, World!");
        }
    }
}
