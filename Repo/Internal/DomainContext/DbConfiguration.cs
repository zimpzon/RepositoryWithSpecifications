using Microsoft.EntityFrameworkCore;
using Repo.Internal.Entities;

namespace Repo.Internal.DomainContext
{
	internal class DbConfiguration
	{
		public static void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite("Data Source=sqLite.db;Mode=Memory;Cache=Shared");
			}
		}

		public static void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Employee configuration
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.HasMany(e => e.Jobs);
				entity.HasMany(e => e.Tasks);
			});

			// Job configuration
			modelBuilder.Entity<Job>(entity =>
			{
				entity.HasKey(j => j.Id);
				entity.HasMany(j => j.JobTasks);
			});

			// JobTask configuration
			modelBuilder.Entity<JobTask>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.HasOne(t => t.Job);
				entity.HasMany(t => t.Employees);
			});
		}
	}
}
