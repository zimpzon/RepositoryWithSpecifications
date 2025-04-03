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

        public void SeedTestData()
        {
            var nested = new Job()
            {
                Employees = [new Employee() { Name = "Mr. Yay" }]
            };
            Jobs.Add(nested);
            SaveChanges();

            if (!Employees.Any() && !Jobs.Any() && !JobTasks.Any())
            {
                var employees = new[]
                {
                    new Employee { Name = "Alice Johnson" },
                    new Employee { Name = "Bob Smith" },
                    new Employee { Name = "Charlie Davis" },
                    new Employee { Name = "Dana White" },
                    new Employee { Name = "Ethan Brown" }
                };
                Employees.AddRange(employees);
                SaveChanges();

                var jobs = new[]
                {
                    new Job { Name = "Software Upgrade", Employees = new[] { employees[0], employees[1] } },
                    new Job { Name = "System Maintenance", Employees = new[] { employees[1], employees[2] } },
                    new Job { Name = "Security Audit", Employees = new[] { employees[2], employees[3] } },
                    new Job { Name = "Cloud Migration", Employees = new[] { employees[3], employees[4] } },
                    new Job { Name = "Customer Support Training", Employees = new[] { employees[4], employees[0] } }
                };
                Jobs.AddRange(jobs);
                SaveChanges();

                var jobTasks = new[]
                {
                    new JobTask { Name = "Update backend services", Job = jobs[0], Employees = new[] { employees[0], employees[1] } },
                    new JobTask { Name = "Refactor database schema", Job = jobs[0], Employees = new[] { employees[1], employees[2] } },
                    new JobTask { Name = "Perform routine checks", Job = jobs[1], Employees = new[] { employees[2], employees[3] } },
                    new JobTask { Name = "Check for vulnerabilities", Job = jobs[2], Employees = new[] { employees[3], employees[4] } },
                    new JobTask { Name = "Run penetration tests", Job = jobs[2], Employees = new[] { employees[4], employees[0] } },
                    new JobTask { Name = "Migrate databases to cloud", Job = jobs[3], Employees = new[] { employees[0], employees[1] } },
                    new JobTask { Name = "Optimize cloud costs", Job = jobs[3], Employees = new[] { employees[1], employees[2] } },
                    new JobTask { Name = "Develop customer service guidelines", Job = jobs[4], Employees = new[] { employees[2], employees[3] } },
                    new JobTask { Name = "Conduct training sessions", Job = jobs[4], Employees = new[] { employees[3], employees[4] } },
                    new JobTask { Name = "Update system logs and reports", Job = jobs[1], Employees = new[] { employees[4], employees[0] } }
                };
                JobTasks.AddRange(jobTasks);
                SaveChanges();
            }
        }
    }
}
