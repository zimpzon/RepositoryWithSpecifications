using Microsoft.Extensions.DependencyInjection;
using Repo.Internal.DomainContext;
using Repo.Public.Repos;
using Repo.Public.Specs;
using Repo.Public.Specs.JobSpec;
using Repo.Public.UOW;
using Results;

namespace ArchitectureTest
{
	internal class Program
    {
        static Result<string> Test(bool success)
        {
            string res = $"success = {success}";
            return success ? Result<string>.Success(res) : Result<string>.Fail("503", "InternalError");
        }

        static async Task Main(string[] args)
        {
            // TODO: try error codes (result, Error)
            var res1 = Test(true);
            var res2 = Test(false);

            var serviceProvider = BuildServiceProvider();

            var jobRepo = serviceProvider.GetRequiredService<IJobRepo>();

			var singleJobWithChildrenSpec = new JobSpecGetById(id: 1, childrenInclude: ChildrenInclude.Nested);
			var jobWithChildren = (await jobRepo.List(singleJobWithChildrenSpec)).SingleOrDefault();

			Console.WriteLine(jobWithChildren);
        }

		private static IServiceProvider BuildServiceProvider()
		{
            // .Use[xxx] pattern to hide implementation details.
            var serviceProvider = new ServiceCollection().
                AddSingleton<IDbContextFactory, DbSqLiteContextFactory>().
                AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>().
                AddSingleton<IJobRepo, JobRepo>().
                BuildServiceProvider();

            var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory>();
            using var context = dbContextFactory.CreateDbContext();
            context.SeedTestData();

            return serviceProvider;
        }
    }
}
