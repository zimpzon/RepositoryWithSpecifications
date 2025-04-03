using Microsoft.EntityFrameworkCore;
using Repo.Internal.Entities;

namespace Repo.Internal.DomainContext
{
	public class DbDomainContext : DbContext
	{
		internal DbSet<Employee> Employees { get; set; } = null!;
		internal DbSet<Job> Jobs { get; set; } = null!;
		internal DbSet<JobTask> JobTasks { get; set; } = null!;

		public DbDomainContext(DbContextOptions<DbDomainContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			DbConfiguration.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			DbConfiguration.OnModelCreating(modelBuilder);
		}
	}
}
